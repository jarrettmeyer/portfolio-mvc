﻿using System;
using System.Collections.Generic;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Portfolio.Lib.Data;
using Portfolio.Lib.DTOs;
using Portfolio.Lib.Models;

namespace Portfolio.Lib.Services
{
    public class TaskUpdateServiceImplTests
    {
        private Mock<IRepository> mockRepository;
        private ITaskUpdateService service;
        private Task task;
        private TaskDTO taskDto;
        private Mock<ITransactionAdapter> mockTransaction;

        [SetUp]
        public void Before_each_test()
        {
            SetUpMockRepository();
            taskDto = new TaskDTO { Id = 123 };
            task = new Task();

            service = new TaskUpdateServiceImpl(mockRepository.Object);
        }

        [Test]
        public void It_should_add_new_tags_to_a_task()
        {
            taskDto.Tags = new List<TagDTO>
            {
                new TagDTO(1, "tag-1", "Tag 1"),
                new TagDTO(2, "tag-2", "Tag 2")
            }.ToArray();

            task = service.UpdateTask(taskDto);

            task.Tags.Count.Should().Be(2);
            task.Tags[0].Slug.Should().Be("tag-1");
            task.Tags[1].Slug.Should().Be("tag-2");
        }

        [Test]
        public void It_should_commit_the_transaction()
        {
            service.UpdateTask(taskDto);
            mockTransaction.Verify(x => x.Commit());
        }

        [Test]
        public void It_should_create_a_new_transaction()
        {
            service.UpdateTask(taskDto);
            mockRepository.Verify(x => x.BeginTransaction());
        }

        [Test]
        public void It_should_fetch_a_task()
        {
            taskDto.Id = 123;
            task = service.UpdateTask(taskDto);
            mockRepository.Verify(x => x.Load<Task>(123), Times.Once());
            task.Id.Should().Be(123);
        }

        [Test]
        public void It_should_remove_tags_that_no_longer_belong()
        {
            task.Tags.Add(new Tag { Id = 1, Slug = "tag-1" });
            task.Tags.Add(new Tag { Id = 2, Slug = "tag-2" });
            taskDto.Tags = new List<TagDTO>
            {
                new TagDTO(1, "tag-1", "Tag 1"),
                new TagDTO(3, "tag-3", "Tag 3")
            }.ToArray();

            task = service.UpdateTask(taskDto);

            task.Tags.Count.Should().Be(2);
            task.Tags[0].Slug.Should().Be("tag-1");
            task.Tags[1].Slug.Should().Be("tag-3");
        }

        [Test]
        public void It_should_update_task_properties()
        {
            taskDto.Description = "This is a description";
            taskDto.DueOn = new DateTime(2013, 12, 31);
            taskDto.Title = "This is a title";

            task = service.UpdateTask(taskDto);

            task.Description.Should().Be("This is a description");
            task.DueOn.Should().Be(new DateTime(2013, 12, 31));
            task.Title.Should().Be("This is a title");
            task.UpdatedAt.Should().BeCloseTo(DateTime.UtcNow);
        }

        private void SetUpMockRepository()
        {
            mockRepository = new Mock<IRepository> { DefaultValue = DefaultValue.Mock };
            mockTransaction = new Mock<ITransactionAdapter>();
            mockRepository.Setup(x => x.BeginTransaction()).Returns(mockTransaction.Object);
            mockRepository.Setup(x => x.Load<Task>(It.IsAny<int>())).Returns<int>(id =>
            {
                task.Id = id;
                return task;
            });
            mockRepository.Setup(x => x.Load<Tag>(1)).Returns(new Tag { Id = 1, Slug = "tag-1", Description = "Tag 1" });
            mockRepository.Setup(x => x.Load<Tag>(2)).Returns(new Tag { Id = 2, Slug = "tag-2", Description = "Tag 2" });
            mockRepository.Setup(x => x.Load<Tag>(3)).Returns(new Tag { Id = 3, Slug = "tag-3", Description = "Tag 3" });
            mockRepository.Setup(x => x.Load<Tag>(4)).Returns(new Tag { Id = 4, Slug = "tag-4", Description = "Tag 4" });
        }
    }
}
