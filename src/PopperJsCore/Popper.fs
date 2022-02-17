// ts2fable 0.7.1
module rec PopperJsCore.Popper
open System
open Fable.Core
open Fable.Core.JS
open Browser.Types

type popperGenerator = __createPopper.popperGenerator
type detectOverflow = __createPopper.detectOverflow
let [<Import("defaultModifiers","@popperjs/core/lib/popper")>] defaultModifiers: ResizeArray<obj> = jsNative
let [<Import("createPopper","@popperjs/core/lib/popper")>] createPopper: (U2<Element, obj> -> HTMLElement -> obj -> obj) = jsNative
