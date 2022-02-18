namespace Fable.Popper.Demo

open Browser.Types
open Fable.Core
open Feliz
open Browser.Dom
open Fable.Core.JsInterop
//open PopperJsCore


module App =
   
    
    importSideEffects "./styles.css"
    
    let popcorn = document.querySelector("#popcorn")
    let tooltip = document.querySelector("#tooltip") :?> HTMLElement
    
    let settings = createObj [
        "placement" ==> "top"
        "modifiers" ==> [|
            createObj [
                "name" ==> "offset"
                "options" ==> createObj [
                    "offset" ==> [|0;8|]
                ]
            ]
            
        |]
    ]
    PopperJsCore.CreatePopper.createPopper (popcorn, tooltip, settings) |> ignore
    
    
//    [<ReactComponent>]
//    let HelloWorld() =
//        let (count, setCount) = React.useState(0)
//        
//        
//        
//        Html.div [
//            Html.div [
//            prop.id "popcorn"
//            prop.ariaDescribedBy "tooltip"
//            ]
//            Html.div [
//                prop.id "tooltip"
//                prop.role "tooltip"
//                prop.children [
//                    Html.text "My tooltip"
//                    Html.div [
//                        prop.id "arrow"
//                        prop.custom ("data-popper-arrow","")
//                    ]
//                ]
//            ]
//        ]
//        
//    
//
//    ReactDOM.render(
//        HelloWorld(),
//        document.getElementById "app"
//    )