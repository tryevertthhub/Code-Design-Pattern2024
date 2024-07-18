mod render;

use render::render;

use gui::GuiFactoryDynamic;
use macos_gui::factory::MacFactory;
use windows_gui::factory::WindowsFactory;

fn main() {
    let windows = false;

    let factory: &dyn GuiFactoryDynamic = if windows {
        &WindowsFactory
    } else {
        &MacFactory
    };

    let button = factory.create_button();
    button.press();
    render(factory);
}