// ts2fable 0.7.1
module PopperJsCore.CreatePopper
open System
open Fable.Core
open Fable.Core.JS
open Browser.Types
open PopperJsCore.Enums
open PopperJsCore.Types
open Fable.Core.JsInterop

type Array<'T> = System.Collections.Generic.IList<'T>
type [<AllowNullLiteral>] PopperGeneratorArgs =
    abstract defaultModifiers: Array<Modifier<obj option, obj option>> option with get, set
    abstract defaultOptions: obj option with get, set
    
    

type PopperModifier() =
    let mutable modifier = createEmpty<Modifier<string,obj>>
    
    member inline this.withName(name) =
        modifier.name <- name
        this
    member inline this.withEnabled(enabled) =
        modifier.enabled <- enabled
        this
    member inline this.withPhase(phase) =
        modifier.phase <- phase
        this
    
    member inline this.withRequires(requires) =
        modifier.requires <- Some requires
        this
    
    member inline this.withRequiresIfExists(requiresIfExists) =
        modifier.requiresIfExists <- Some requiresIfExists
        this
    
    member inline this.withFn(fn) =
        modifier.fn <- fn
        this
        
    member inline this.withEffect(effect) =
        modifier.effect <- Some effect
        this
    
    member inline this.withOptions(options) =
        modifier.options <- Some options
        this
    
    member inline this.withData(data) =
        modifier.data <- Some data
        this
        
    member inline this.Finalize() = modifier

type PopperOptions() =
    
    let mutable options = createEmpty<OptionsGeneric<Modifier<string,obj>>>
    
    member inline this.withPlacement(p: Placement) =
        options.placement <- p
        this
    
    member inline this.withModifiers(m)=
        options.modifiers <- m
        this
        
    member inline this.withAddedModifier(m: PopperModifier)=
        match options.modifiers with
        | Some _ -> options.modifiers.Value.Add(m.Finalize())
        | None -> options.modifiers <- Some [|m.Finalize()|]
        this
    
    member inline  this.withStrategy(s)=
        options.strategy <- s
        this
    
    member inline  this.withOnFirstUpdate(f)=
        options.onFirstUpdate <- f
        this
    
    member inline this.Finalize() = options


type Popper() =
    [<Import("createPopper","@popperjs/core")>]
    static member createPopper(reference: Element, popper: HTMLElement, ?options:OptionsGeneric<Modifier<string,obj>>): Instance = jsNative
    
    
[<Import("createPopper","@popperjs/core")>]
let createPopper(reference: Element, popper: HTMLElement, options: obj): Instance = jsNative

type [<AllowNullLiteral>] IExports =
    abstract popperGenerator: ?generatorOptions: PopperGeneratorArgs -> (U2<Element, VirtualElement> -> HTMLElement -> obj -> Instance)

