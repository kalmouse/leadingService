@rem Copyright 2016, Google Inc.
@rem All rights reserved.
@rem
@rem Redistribution and use in source and binary forms, with or without
@rem modification, are permitted provided that the following conditions are
@rem met:
@rem
@rem     * Redistributions of source code must retain the above copyright
@rem notice, this list of conditions and the following disclaimer.
@rem     * Redistributions in binary form must reproduce the above
@rem copyright notice, this list of conditions and the following disclaimer
@rem in the documentation and/or other materials provided with the
@rem distribution.
@rem     * Neither the name of Google Inc. nor the names of its
@rem contributors may be used to endorse or promote products derived from
@rem this software without specific prior written permission.
@rem
@rem THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
@rem "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
@rem LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
@rem A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT
@rem OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
@rem SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
@rem LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
@rem DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
@rem THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
@rem (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
@rem OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

@rem Generate the C# code for .proto files

setlocal

@rem enter this directory

set TOOLS_PATH=%USERPROFILE%\.nuget\packages\grpc.tools\1.12.0\tools\windows_x64
set SCRIPTDIR=%~dp0
set SCRIPTDIR=%SCRIPTDIR:~0,-1%
for %%d in (%SCRIPTDIR%) do set PROJDIR=%%~dpd

echo %PROJDIR%

%TOOLS_PATH%\protoc.exe -I %PROJDIR%proto --csharp_out %PROJDIR%leadingService\rpc  %PROJDIR%proto\common.proto --grpc_out %PROJDIR%leadingService\rpc --plugin=protoc-gen-grpc=%TOOLS_PATH%\grpc_csharp_plugin.exe
%TOOLS_PATH%\protoc.exe -I %PROJDIR%proto --csharp_out %PROJDIR%leadingServiceClient\rpc  %PROJDIR%proto\common.proto --grpc_out %PROJDIR%leadingServiceClient\rpc --plugin=protoc-gen-grpc=%TOOLS_PATH%\grpc_csharp_plugin.exe
%TOOLS_PATH%\protoc.exe -I %PROJDIR%proto --csharp_out %PROJDIR%leadingService\rpc  %PROJDIR%proto\warehouse.proto --grpc_out %PROJDIR%leadingService\rpc --plugin=protoc-gen-grpc=%TOOLS_PATH%\grpc_csharp_plugin.exe
%TOOLS_PATH%\protoc.exe -I %PROJDIR%proto --csharp_out %PROJDIR%leadingServiceClient\rpc  %PROJDIR%proto\warehouse.proto --grpc_out %PROJDIR%leadingServiceClient\rpc --plugin=protoc-gen-grpc=%TOOLS_PATH%\grpc_csharp_plugin.exe
%TOOLS_PATH%\protoc.exe -I %PROJDIR%proto --csharp_out %PROJDIR%leadingService\rpc  %PROJDIR%proto\region.proto --grpc_out %PROJDIR%leadingService\rpc --plugin=protoc-gen-grpc=%TOOLS_PATH%\grpc_csharp_plugin.exe
%TOOLS_PATH%\protoc.exe -I %PROJDIR%proto --csharp_out %PROJDIR%leadingServiceClient\rpc  %PROJDIR%proto\region.proto --grpc_out %PROJDIR%leadingServiceClient\rpc --plugin=protoc-gen-grpc=%TOOLS_PATH%\grpc_csharp_plugin.exe

endlocal
