function SideMenuHandler(target) {
    if (target === 'All') {
        $("section.scroll-section").css("display", "block");
        return;
    }

    $("section.scroll-section").css("display", "none");
    $(target).css("display", "block");
}