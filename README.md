# Fable.PopperJS

Fable binding for Tooltip & Popover Positioning Engine [PopperJS](https://popper.js.org/).


## Installation Using Femto

Using [Femto](https://github.com/Zaid-Ajaj/Femto) you can install the library and its npm dependency in one go:
```
femto install Fable.PopperJS
```

## Installation

Install the binding from Nuget via paket
```
paket add Fable.PopperJS --project path/to/Proj.fsproj
```

Install the actual Javascript library `@popperjs/core` from npm
```
npm install @popperjs/core@2.11.2
```

## Usage


Via plain JS objects:

```f#
open Browser.Types
open Browser.Dom
open Fable.Core.JsInterop
open PopperJsCore.Enums
open PopperJsCore.CreatePopper

let popcorn = document.querySelector("#popcorn")
let tooltip = document.querySelector("#tooltip") :?> HTMLElement

let settingsjs = createObj [
    "placement" ==> "bottom"
    "modifiers" ==> [|
        createObj [
            "name" ==> "offset"
            "options" ==> createObj [
                "offset" ==> [|0;8|]
            ]
        ]
        
    |]
]

createPopper(popcorn,tooltip,settingsjs) |> ignore
```


Via strongly-type F# DSL:
```f#
open Browser.Types
open Browser.Dom
open Fable.Core.JsInterop
open PopperJsCore.Enums
open PopperJsCore.CreatePopper

let popcorn = document.querySelector("#popcorn")
let tooltip = document.querySelector("#tooltip") :?> HTMLElement
let settings = PopperOptions()
                   .withPlacement(Placement.Case2 BasePlacement.Right)
                   .withAddedModifier(PopperModifier()
                                          .withName("offset")
                                          .withOptions(createObj [ "offset" ==> [0;8] ])
                                      )
                   .Finalize()
Popper.createPopper(popcorn, tooltip, settings) |> ignore
```
