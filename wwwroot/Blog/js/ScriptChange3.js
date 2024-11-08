function OnDelete(id) {

    if (confirm('Вы уверенны, что хотите удалить карточку?')) {

        $.ajax({
            type: "delete",
            url: `Delete?id=${id}`,
            headers: { "Accept": "application/json", "Content-Type": "application/json" },

            success: function (msg) {

                if (msg == 'successfully') {
                    window.location.href = "/Blog/Editable";
                }
                else {
                    window.location.href = "/Exception/Mistake";
                }
            }
        });

    }
}