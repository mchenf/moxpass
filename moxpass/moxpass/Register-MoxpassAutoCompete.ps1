$scriptBlock = {
	param(
		$wordToComplete,
		$commandAst,
		$cursorPosition)
		moxpass complete $cursorPosition $commandAst | `
			ForEach-Object {
				[System.Management.Automation.CompletionResult]::new( `
					$_, $_, 'ParameterValue', $_
				)
			}
}

Register-ArgumentCompleter `
	-Native `
	-CommandName moxpass `
	-ScriptBlock $scriptBlock