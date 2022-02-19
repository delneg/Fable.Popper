# Fable.PopperJS & Fable.PopperJS.React

Fable binding for Tooltip & Popover Positioning Engine [PopperJS](https://popper.js.org/).

and

[React-popper](https://popper.js.org/react-popper/v2/)

## Installation Using Femto

Using [Femto](https://github.com/Zaid-Ajaj/Femto) you can install the library and its npm dependency in one go:
```
femto install Fable.PopperJS
```

or for React version:
```
femto install Fable.PopperJS.React
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

For React version
```
npm install @popperjs/core@2.11.2
npm install react-popper@2.2.5
```

## Usage


Via plain JS objects (https://codesandbox.io/s/github/popperjs/website/tree/master/examples/placement):

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


Via strongly-typed F# DSL:
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


Fable.PopperJS.React as a React Hook (https://popper.js.org/react-popper/v2/#example):
```f#
open Browser.Types
open Feliz
open Browser.Dom
open Fable.Core.JsInterop
open PopperJsCore.Enums
open PopperJsCore.CreatePopper
open Fable.PopperJS.React
open Fable.Core.JS

[<ReactComponent>]
let Example() =
    let (referenceElement: Element, setReferenceElement) = React.useState(null)
    let (popperElement: Element, setPopperElement) = React.useState(null)
    let (arrowElement: Element, setArrowElement) = React.useState(null)
    
    let options = PopperOptions()
                      .withAddedModifier(PopperModifier()
                                             .withName("arrow")
                                             .withOptions(createObj ["element" ==> arrowElement])
                                         )
                      .Finalize()
    let ret = React.usePopper(Fable.Core.Case1 referenceElement, popperElement :?> HTMLElement, options :?> usePopperOptions)
    Html.div [
        prop.style [style.paddingTop 50]
        prop.children[
            Html.button [
                prop.type' "button"
                prop.ref setReferenceElement
                prop.text "Reference element"
            ]
            Html.div[
                prop.ref setPopperElement
                prop.custom("style",ret.styles.popper)
                if ret.attributes.popper.IsSome then
                    for (key,value) in Constructors.Object.entries ret.attributes.popper.Value do
                        prop.custom(key,value)
                prop.children [
                    Html.text "Popper element"
                    Html.div [
                        prop.ref setArrowElement
                        prop.custom("style",ret.styles.arrow)
                    ]
                ]
            ]
        ]
    ]
```