namespace Fable.Popper.Demo

open Browser.Types
open Feliz
open Browser.Dom
open Fable.Core.JsInterop
open Fable.PopperJS.Enums
open Fable.PopperJS.CreatePopper
open Fable.PopperJS.React
open Fable.Core.JS
module App =
   
    
    importSideEffects "./styles.css"
    
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
  
    
    let popcorn2 = document.querySelector("#popcorn2")
    let tooltip2 = document.querySelector("#tooltip2") :?> HTMLElement
    let settings = PopperOptions()
                       .withPlacement(Placement.Case2 BasePlacement.Right)
                       .withAddedModifier(PopperModifier()
                                              .withName("offset")
                                              .withOptions(createObj [ "offset" ==> [0;8] ])
                                          )
                       .Finalize()
    
    Popper.createPopper(popcorn2, tooltip2, settings) |> ignore
    
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
                    prop.text "React hook"
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
        
    

    ReactDOM.render(
        Example(),
        document.getElementById "react-app"
    )