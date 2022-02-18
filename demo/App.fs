namespace Fable.Popper.Demo

open Browser.Types
open Feliz
open Browser.Dom
open Fable.Core.JsInterop
open PopperJsCore.Enums
open PopperJsCore.CreatePopper


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
    let HelloWorld() =
        let (count, setCount) = React.useState(0)
        
        
        Html.div [
            prop.style [
                style.paddingTop 50
                style.color.coral
            ]
            
            prop.children [
                Html.p [
                    prop.text count
                ]
                Html.button [
                    prop.text "Increment"
                    prop.onClick (fun _ -> setCount (count+1))
                ]
            ]
        ]
        
    

    ReactDOM.render(
        HelloWorld(),
        document.getElementById "react-app"
    )