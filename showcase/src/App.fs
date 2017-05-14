namespace Hink.Showcase

open Hink.Core
open Hink.Widgets.Container
open Hink.Widgets.Display
open Hink.Widgets.Interactive
open Fable.Import

module Main =

  // Application code
  let app = Application()
  app.Init()

  // Build UI
  let mutable counter = 0
  // let button = Button("Click me")
  // button.UI.x <- 20.
  // button.UI.y <- 10.

  // let buttonText count = sprintf "Count: %i" count
  // let buttonLabel = Label(buttonText counter)
  // buttonLabel.UI.x <- 110.
  // buttonLabel.UI.y <- 20.

  // button.OnClick.Add(
  //   fun _ ->
  //     counter <- counter + 1
  //     buttonLabel.Text <- buttonText counter
  // )

  let label = Label("I am a label")
  label.UI.x <- 20.
  label.UI.y <- 60.

  // let checkbox = Checkbox()
  // checkbox.UI.x <- 20.
  // checkbox.UI.y <- 100.

  // let checkboxText state = sprintf "Checkbox value: %b" state
  // let checkboxLabel = Label(checkboxText checkbox.State)
  // checkboxLabel.UI.x <- 55.
  // checkboxLabel.UI.y <- 103.

  // checkbox.StateChange.Add(fun evt ->
  //   checkboxLabel.Text <- checkboxText evt.NewState
  // )

  let switch = Switch(20., 150.)

  let switchText state = sprintf "Checkbox value: %b" state
  let switchLabel = Label(switchText switch.State)
  switchLabel.UI.x <- 100.
  switchLabel.UI.y <- 155.

  switch.OnStateChanged.Add(fun evt ->
    switchLabel.Text <- switchText evt.NewState
  )

  let window = Window()
  window.UI.x <- 20.
  window.UI.y <- 200.


  let defaultButton = Button()

  let customButton =
    Button(
      x = 50.,
      y = 50.
    )

  let buttonWithCallback =
    Button(
      x = 100.,
      y = 100.,
      onClick = (fun _ -> Browser.console.log("constructor callback"))
    )

  let withOnClick (onClick: 'T -> unit) widget =
    (widget :> IClickable<'T>).OnClick.Add(onClick)

  let withOnStateChange (onStateChange: 'T -> unit) widget =
    (widget :> IStateChangeable<'T>).OnStateChange.Add(onStateChange)

  customButton
  |> withOnClick (fun event ->
    Browser.console.log("ko")
  )

  let checkbox =
    Checkbox(
      x = 20.,
      y = 100.,
      onStateChange = (fun event -> Browser.console.log event.NewState)
    )

  // app.AddWidget(button)
  // app.AddWidget(buttonLabel)
  app.AddWidget(label)
  // app.AddWidget(checkbox)
  // app.AddWidget(checkboxLabel)
  app.AddWidget(switch)
  app.AddWidget(switchLabel)
  //app.AddWidget(window)

  app
    .RootContainer
    .addChild(defaultButton, customButton, buttonWithCallback, checkbox)
    |> ignore

  // Start app
  app.Start()

  Fable.Import.Browser.console.log Hink.Theme.Default.TextStyle
