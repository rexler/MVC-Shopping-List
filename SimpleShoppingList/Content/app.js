function ListItemDeleted(elem) {
    if (elem.success) {
        $(".manage-list-item[data-item-id='" + elem.id + "']").remove();
        console.log("Item deleted");
    }
    else {
        console.log("Error deleting item. " + elem.message);
    }
}