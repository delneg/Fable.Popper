namespace Fable.Popper.Demo

open Browser.Types
open Feliz
open Browser.Dom
open Fable.Core.JsInterop
open PopperJsCore.Enums
open PopperJsCore.CreatePopper
open Fable.PopperJS.React

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
        let referenceElement = React.useRef(None)
        let popperElement = React.useRef(None)
        let arrowElement = React.useRef(None)
        
        let options = PopperOptions()
                          .withAddedModifier(PopperModifier()
                                                 .withName("arrow")
                                                 .withOptions(createObj ["element" ==> arrowElement])
                                             )
                          .Finalize()
        let ret = React.usePopper(referenceElement, popperElement, options :?> usePopperOptions)
        Fable.Core.JS.console.log(ret)
        Html.div [
            prop.children[
                Html.button [
                    prop.type' "button"
                    prop.ref referenceElement
                ]
//                Html.div (List.append ret.attributes.popper [
                Html.div[
                    prop.ref popperElement
//                    prop.style ret.styles.popper
                    prop.text "Popper element"
                    prop.children [
                        Html.div [
                            prop.ref arrowElement
//                            prop.style 
//                            prop.style ret.styles.arrow
                        ]
                    ]
                ]
            ]
        ]
        
    

    ReactDOM.render(
        Example(),
        document.getElementById "react-app"
    )