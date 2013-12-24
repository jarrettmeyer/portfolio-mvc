properties {

    $sourcePath = '.\src'

}

task CompileDebug {

    msbuild.exe /p:Configuration=Debug .\src\Portfolio\Portfolio.csproj
    msbuild.exe /p:Configuration=Debug .\src\Portfolio.API\Portfolio.API.csproj

}

task NUnit -depends CompileDebug {

    msbuild.exe /p:Configuration=Debug .\src\Portfolio.Tests\Portfolio.Tests.csproj
    nunit-console.exe .\src\Portfolio.Tests\bin\Debug\Portfolio.Tests.dll

}