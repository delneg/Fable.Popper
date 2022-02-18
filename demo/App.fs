namespace Fable.Popper.Demo

open Feliz
open Browser.Dom
open Fable.Core.JsInterop
   


module App =
    [<ReactComponent>]
    let HelloWorld() =
        let (count, setCount) = React.useState(0)
        Html.div [
            Html.h1 count
            Html.button [
                prop.onClick (fun _ -> setCount(count + 1))
                prop.text "Increment"
            ]
        ]
    

    ReactDOM.render(
        HelloWorld(),
        document.getElementById "app"
    )