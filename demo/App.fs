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
        let (referenceElement: Element, setReferenceElement) = React.useState(null)
//        let referenceElement = React.useRef(None)
//        let popperElement = React.useRef(None)
//        let arrowElement = React.useRef(None)
        let (popperElement: Element, setPopperElement) = React.useState(null)
        let (arrowElement: Element, setArrowElement) = React.useState(null)
        
        let options = PopperOptions()
                          .withAddedModifier(PopperModifier()
                                                 .withName("arrow")
                                                 .withOptions(createObj ["element" ==> arrowElement])
                                             )
                          .Finalize()
        let ret = React.usePopper(Fable.Core.Case1 referenceElement, popperElement :?> HTMLElement, options :?> usePopperOptions)
        Fable.Core.JS.console.log(ret)
//        ret.attributes.popper
//        Fable.Core.JsInterop.
        
        if ret.attributes.popper.IsSome then
            Fable.Core.JS.console.log(Fable.Core.JS.Constructors.Object.keys(ret.attributes.popper))
//        for kv in ret.attributes.popper do
//            Fable.Core.JS.console.log(kv)
//            Fable.Core.JS.console.log(kv.valueOf())
        let popperProps =
            match ret.attributes.popper with
            | Some attrs ->
                [
                    for (key,value) in Fable.Core.JS.Constructors.Object.entries attrs do
                        yield prop.custom(key,value)
                ]
            | None -> []
        Html.div [
            prop.style [style.paddingTop 50]
            prop.children[
                Html.button [
                    prop.type' "button"
                    prop.ref setReferenceElement
                    prop.text "Reference element"
                    prop.onClick (fun _ -> if ret.update.IsSome then ret.update.Value())
                ]
                Html.div[
                    prop.ref setPopperElement
                    prop.custom("style",ret.styles.popper)
                    yield! popperProps
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