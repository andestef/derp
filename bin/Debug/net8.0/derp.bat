@echo off
set edit=false
set derpdir=C:\\Users\\alexa\\Documents\\coding\\cs\\derp\\bin\\Debug\\net8.0
echo "%*" | find "--edit">nul && set edit=true
echo "%*" | find "-e">nul && set edit=true
set x=
set return=
if "%edit%"=="false" (
	for /f "delims=" %%x in ('"%derpdir%\\derp" DERPBAT %*') do (
		cd "%%x"
		setlocal ENABLEDELAYEDEXPANSION
		set a="%%x"
		if "!a:~1,1!"=="`" (
			echo !a!
			cd %cd%
		) 
		setlocal DISABLEDELAYEDEXPANSION
	)
) else (
	"%derpdir%\\derp" EDIT %*
)