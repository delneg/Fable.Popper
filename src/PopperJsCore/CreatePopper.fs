// ts2fable 0.7.1
module PopperJsCore.CreatePopper
open System
open Fable.Core
open Fable.Core.JS
open Browser.Types
open PopperJsCore.Types
type Array<'T> = System.Collections.Generic.IList<'T>
type [<AllowNullLiteral>] PopperGeneratorArgs =
    abstract defaultModifiers: Array<Modifier<obj option, obj option>> option with get, set
    abstract defaultOptions: obj option with get, set
    
[<Import("createPopper","@popperjs/core")>]
let createPopper(reference: Element, popper: HTMLElement, options: obj): Instance = jsNative

type [<AllowNullLiteral>] IExports =
    abstract popperGenerator: ?generatorOptions: PopperGeneratorArgs -> (U2<Element, VirtualElement> -> HTMLElement -> obj -> Instance)

