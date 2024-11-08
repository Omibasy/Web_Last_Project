
    function OnDelete(delete_card) {

        if (confirm('Вы уверенны, что хотите удалить карточку?')) {

            let card_title = document.querySelector(delete_card).innerText;

            $.ajax({
                type: "delete",
                url: `Delete?title=${card_title}`,
                headers: { "Accept": "application/json", "Content-Type": "application/json" },

                success: function (msg) {

                    if (msg == 'successfully') {
                        window.location.href = "/Projects/Editable";
                    }
                    else {
                        window.location.href = "/Exception/Mistake";
                    }
                }
            });

        }
    }





