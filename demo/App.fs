namespace Fable.Popper.Demo

open Browser.Types
open Fable.Core
open Feliz
open Browser.Dom
open Fable.Core.JsInterop
open PopperJsCore
open PopperJsCore.Enums
open PopperJsCore.Types


module App =
   
    
    importSideEffects "./styles.css"
    
    let popcorn = document.querySelector("#popcorn")
    let tooltip = document.querySelector("#tooltip") :?> HTMLElement
    
    let settingsjs = createObj [
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
    
//    type Settings() =
//        interface OptionsGeneric<_> with
//            member this.placement = BasePlacement.Top
//            
    
//    let settings() = { new OptionsGeneric<Modifier<string,obj>> with
//                            member this.placement = BasePlacement.Top
//                            member this.modifiers = [||]
//                            member this.strategy = PositioningStrategy.Absolute
//                            member this.onFirstUpdate = None
//                        }
//    let settings = PopperJsCore.CreatePopper.PopperOptions()

//    let settings = {
//        Placement = Placement.Case2 BasePlacement.Top
//        Modifiers = Some [|
//            createObj [
//                "name" ==> "offset"
//                "options" ==> createObj [
//                    "offset" ==> [|0;8|]
//                ]
//            ]
//        |]
//        Strategy = None
//        onFirstUpdate = None }
    let settings = PopperJsCore.CreatePopper.PopperOptions()
                       .withUpdatedPlacement(Placement.Case2 BasePlacement.Left)
                       .withUpdatedModifiers([|
                            createObj [
                                "name" ==> "offset"
                                "options" ==> createObj [
                                    "offset" ==> [|0;8|]
                                ]
                            ]
                        |])
    JS.console.log(settings)
//    CreatePopper.createPopper (popcorn, tooltip,settings) |> ignore
    PopperJsCore.CreatePopper.Popper.createPopper(popcorn, tooltip, jsOptions<OptionsGeneric<obj>>(fun x ->
        x.placement <- Placement.Case2 BasePlacement.Top
        x.modifiers <- [|
                            createObj [
                                "name" ==> "offset"
                                "options" ==> createObj [
                                    "offset" ==> [|0;8|]
                                ]
                            ]
                        |]
        )) |> ignore
    
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