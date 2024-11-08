function RemoveSlade(item, index) {
    let servicesItems = document.querySelectorAll(".services__list__item");

    if (servicesItems.length <= 1) {
        return;
    }

    var a = item.querySelector("span").innerHTML.trim();
    if (confirm(`Вы действительно хотите удалить  \"${a}\"?`)) {
      

        $.ajax({
            type: "delete",
            url: `Delete?index=${index}`,
            headers: { "Accept": "application/json", "Content-Type": "application/json" },


            success: function (msg) {

                if (msg == 'successfully') {
                    window.location.href = "/Services/Change";
                }
                else {
                    window.location.href = "/Exception/Mistake";
                }
            }
        });

    }
}