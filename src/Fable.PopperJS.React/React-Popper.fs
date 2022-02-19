// ts2fable 0.7.1
module rec Fable.PopperJS.React
open System.Collections.Generic
open Fable.Core
open Browser.Types
open PopperJsCore.Enums
open PopperJsCore.Types
open Feliz

type ReadonlyArray<'T> = System.Collections.Generic.IReadOnlyList<'T>

type ManagerProps =
    abstract children: IEnumerable<ReactElement> with get, set


[<ReactComponent(import="Manager", from="react-popper")>]
let Manager (props: ManagerProps) = React.imported()

type usePopperOptions =
    inherit OptionsGeneric<Modifier<string,obj>>
    
    abstract createPopper: (Element * HTMLElement * OptionsGeneric<Modifier<string,obj>>) -> Instance with get,set
    abstract modifiers: ReadonlyArray<Modifier<string,obj>> with get ,set

type usePopperReturnObj<'T> =
    abstract popper: 'T with get,set
    abstract arrow: 'T with get,set

type [<AllowNullLiteral>] usePopperReturn =
    abstract styles: usePopperReturnObj<IReactProperty list> with get, set
    abstract attributes: usePopperReturnObj<JS.Object option>with get, set
    abstract state: State option with get, set
    abstract update: (unit -> unit) option with get, set
    abstract forceUpdate: Instance option with get, set
    
[<AutoOpen>]
module UsePopperExtension = 
    type React with
        [<Hook>]
        [<Import("usePopper","react-popper")>]
        static member inline usePopper(?referenceElement: U2<Element, VirtualElement>,
                                       ?popperElement: HTMLElement,
                                       ?options: usePopperOptions) :usePopperReturn =
            jsNative