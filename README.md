# Conversion Utility

## Overview

A command line application to find and replace text (plain or regex based).

The `SourceDir` along with the find and replace options are configured via a `JSON` file (example below)

## Use Cases

To help migrating to a new version of a library, (i.e., migrating from Bootstrap v3 to v4)

It's intended for use as a starting point for any migrations. I don't expect it will cover all your needs.

## Usage 

```
ConversionUtility.exe C:\temp\conversion-options.json
```

**WARNING: Run at your own risk and take precautions for loss of information / corruption through source control or backups**

## Sample conversion options file contents

``` JSON
{
	"SourceDir": "C:\\src\\MyAppLocation\\",
	"Options":
	[
		{ "Find": "pull-left", "ReplaceWith": "float-left", "Extension": ".cshtml" },
		{ "Find": "pull-right", "ReplaceWith": "float-right", "Extension": ".cshtml" }
	]
}
```