// ts2fable 0.7.1
module PopperJsCore.Types
open System
open Fable.Core
open Fable.Core.JS
open Browser.Types
open PopperJsCore.Enums

type Array<'T> = System.Collections.Generic.IList<'T>


type [<AllowNullLiteral>] Obj =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

type [<AllowNullLiteral>] VisualViewport =
    interface end

type [<AllowNullLiteral>] Window =
    abstract innerHeight: float with get, set
    abstract offsetHeight: float with get, set
    abstract innerWidth: float with get, set
    abstract offsetWidth: float with get, set
    abstract pageXOffset: float with get, set
    abstract pageYOffset: float with get, set
    abstract getComputedStyle: obj with get, set
    abstract addEventListener: ``type``: obj option * listener: obj option * ?optionsOrUseCapture: obj -> unit
    abstract removeEventListener: ``type``: obj option * listener: obj option * ?optionsOrUseCapture: obj -> unit
    abstract Element: Element with get, set
    abstract HTMLElement: HTMLElement with get, set
    abstract Node: Node with get, set
    abstract toString: unit -> string
    abstract devicePixelRatio: float with get, set
    abstract visualViewport: VisualViewport option with get, set
    abstract ShadowRoot: ShadowRoot with get, set

type [<AllowNullLiteral>] Rect =
    abstract width: float with get, set
    abstract height: float with get, set
    abstract x: float with get, set
    abstract y: float with get, set

type [<AllowNullLiteral>] Offsets =
    abstract y: float with get, set
    abstract x: float with get, set

type [<StringEnum>] [<RequireQualifiedAccess>] PositioningStrategy =
    | Absolute
    | Fixed

type [<AllowNullLiteral>] StateRects =
    abstract reference: Rect with get, set
    abstract popper: Rect with get, set

type [<AllowNullLiteral>] StateOffsets =
    abstract popper: Offsets with get, set
    abstract arrow: Offsets option with get, set

type [<AllowNullLiteral>] OffsetData =
    interface end

type [<AllowNullLiteral>] State =
//    abstract elements: StateElements with get, set
//    abstract options: OptionsGeneric<obj option> with get, set
    abstract placement: Placement with get, set
    abstract strategy: PositioningStrategy with get, set
//    abstract orderedModifiers: Array<Modifier<obj option, obj option>> with get, set
    abstract rects: StateRects with get, set
//    abstract scrollParents: StateScrollParents with get, set
//    abstract styles: StateStyles with get, set
//    abstract attributes: StateAttributes with get, set
//    abstract modifiersData: StateModifiersData with get, set
    abstract reset: bool with get, set

type SetAction<'S> =
    U2<'S, ('S -> 'S)>

type [<AllowNullLiteral>] Instance =
    abstract state: State with get, set
    abstract destroy: (unit -> unit) with get, set
    abstract forceUpdate: (unit -> unit) with get, set
    abstract update: (unit -> Promise<obj>) with get, set
    abstract setOptions: (SetAction<obj> -> Promise<obj>) with get, set

type [<AllowNullLiteral>] ModifierArguments<'Options> =
    abstract state: State with get, set
    abstract instance: Instance with get, set
    abstract options: obj with get, set
    abstract name: string with get, set

type [<AllowNullLiteral>] Modifier<'Name, 'Options> =
    abstract name: 'Name with get, set
    abstract enabled: bool with get, set
    abstract phase: ModifierPhases with get, set
    abstract requires: Array<string> option with get, set
    abstract requiresIfExists: Array<string> option with get, set
    abstract fn: (ModifierArguments<'Options> -> U2<State, unit>) with get, set
    abstract effect: (ModifierArguments<'Options> -> U2<(unit -> unit), unit>) option with get, set
    abstract options: obj option with get, set
    abstract data: Obj option with get, set

type StrictModifiers =
    obj

type [<AllowNullLiteral>] EventListeners =
    abstract scroll: bool with get, set
    abstract resize: bool with get, set

type [<AllowNullLiteral>] Options =
    abstract placement: Placement with get, set
    abstract modifiers: Array<obj> with get, set
    abstract strategy: PositioningStrategy with get, set
    abstract onFirstUpdate: (obj -> unit) option with get, set

type [<AllowNullLiteral>] OptionsGeneric<'TModifier> =
    abstract placement: Placement with get, set
    abstract modifiers: Array<'TModifier> option with get, set
    abstract strategy: PositioningStrategy with get, set
    abstract onFirstUpdate: (obj -> unit) option with get, set
    
type [<AllowNullLiteral>] UpdateCallback =
    [<Emit "$0($1...)">] abstract Invoke: arg0: State -> unit

type [<AllowNullLiteral>] ClientRectObject =
    abstract x: float with get, set
    abstract y: float with get, set
    abstract top: float with get, set
    abstract left: float with get, set
    abstract right: float with get, set
    abstract bottom: float with get, set
    abstract width: float with get, set
    abstract height: float with get, set

type [<AllowNullLiteral>] SideObject =
    abstract top: float with get, set
    abstract left: float with get, set
    abstract right: float with get, set
    abstract bottom: float with get, set

type Padding =
    U2<float, obj>

type [<AllowNullLiteral>] VirtualElement =
    abstract getBoundingClientRect: (unit -> ClientRect) with get, set
    abstract contextElement: Element option with get, set

type [<AllowNullLiteral>] StateElements =
    abstract reference: U2<Element, VirtualElement> with get, set
    abstract popper: HTMLElement with get, set
    abstract arrow: HTMLElement option with get, set

type [<AllowNullLiteral>] StateScrollParents =
    abstract reference: Array<U3<Element, Window, VisualViewport>> with get, set
    abstract popper: Array<U3<Element, Window, VisualViewport>> with get, set

type [<AllowNullLiteral>] StateStyles =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj with get, set

type [<AllowNullLiteral>] StateAttributesItem =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> U2<string, bool> with get, set

type [<AllowNullLiteral>] StateAttributes =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> StateAttributesItem with get, set

type [<AllowNullLiteral>] StateModifiersDataArrow =
    abstract x: float option with get, set
    abstract y: float option with get, set
    abstract centerOffset: float with get, set

type [<AllowNullLiteral>] StateModifiersDataHide =
    abstract isReferenceHidden: bool with get, set
    abstract hasPopperEscaped: bool with get, set
    abstract referenceClippingOffsets: SideObject with get, set
    abstract popperEscapeOffsets: SideObject with get, set

type [<AllowNullLiteral>] StateModifiersData =
    abstract arrow: StateModifiersDataArrow option with get, set
    abstract hide: StateModifiersDataHide option with get, set
    abstract offset: OffsetData option with get, set
    abstract preventOverflow: Offsets option with get, set
    abstract popperOffsets: Offsets option with get, set
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set


