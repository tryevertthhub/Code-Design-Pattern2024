mod render;
use render::render;

use macos-gui::factory::MacFactory;
use windows_gui::factory::WindowsFactory;

fn main() {
    let windows = true;

    if windows {
        render(WindowsFactory);
    } else {
        render(MacFactory);
    }
}