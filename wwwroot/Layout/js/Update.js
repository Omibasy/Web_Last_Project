


function ChangingImage(input) {


    let [file] = input.files
    let blah = document.querySelector('#blah');

    if (file) {
        blah.classList.remove('img--none')
        blah.src = URL.createObjectURL(file)
    }
    else
    {
        blah.classList.add('img--none')
    }

}


const validateLayout = new JustValidate('#Form_Layout');

validateLayout.addField('#Name', [
    {
        rule: 'required',
        errorMessage: 'заполните поле'
    },
    {
        rule: 'minLength',
        value: 3,
        errorMessage: "слишком короткое"
    },
    {
        rule: 'maxLength',
        value: 20,
        errorMessage: "слишком длинное"
    }

]);


validateLayout.addField('#file', [
    
      {
        rule: 'maxFilesCount',
        value: 1,
        errorMessage: 'не больше 1 файла'
      },
      {
        rule: 'files',
        value: {
          files: {
            types: ['image/png'],
            extensions: ['png'],
          },
        },
        errorMessage: 'неверный формат'
      },
]);

function AddInputTextMenu()
{
    let inputText = document.querySelectorAll('.layout-header__input');


    for (item of inputText)
    {
        validateLayout.addField(`#${item.id}`, [
            {
                rule: 'customRegexp',
                value: /^[а-яА-я]+$/gi,
                errorMessage: 'только на русском'
            },
            {
                rule: 'required',
                errorMessage: 'заполните поле'
            },
            {
                rule: 'minLength',
                value: 3,
                errorMessage: "слишком короткое"
            },
            {
                rule: 'maxLength',
                value: 13,
                errorMessage: "слишком длинное"
            },


        ]);


    }

}


validateLayout.addField('#Footer',[
    {
        rule: 'required',
        errorMessage: 'поле не должно быть пустым',
    },
    {
        rule: 'minLength',
        value: 4,
        errorMessage: "слишком мало символов",
    },
    {
        rule: 'maxLength',
        value: 100,
        errorMessage: "слишком много символов",
    },
    


],
{
    errorLabelStyle: 
    {
     fontSize: '16px',
     color: '#ffffff', 
    }, 

});

AddInputTextMenu();

validateLayout.onSuccess((event) => {

    let fileBit = [];

    let menuName = [];

    let inputMenuName = document.querySelectorAll('[name="Menu"]');

    for (let item of inputMenuName)
    {
        menuName.push(item.value);
    }


    SumbitForm(fileBit).then((e) =>
    {

        if (fileBit.length < 1)
        {
            fileBit.push("");
        }

        $.ajax({
            type: "put",
            url: 'Set',
            headers: { "Accept": "application/json", "Content-Type": "application/json" },
            data: JSON.stringify(
                {
                    CompanyName: document.querySelector('[name="Name"]').value,

                    Footer: document.querySelector('[name="Footer"]').value,

                    file: fileBit[0],

                    HeadingMenu: menuName
                }
            ),

            success: function (msg) {

                if (msg == 'successfully') {
                    window.location.href = "/Heading/Index";
                }
                else {
                    window.location.href = "/Exception/Mistake";
                }
            }
        });
    });
});


function readFile(file) {
    return new Promise((resolve, reject) => {
        const reader = new FileReader();

        reader.onload = res => {
            resolve(res.target.result);
        };
        reader.onerror = err => reject(err);

        reader.readAsArrayBuffer(file);
    });
}

async function SumbitForm(fileBit) {

    const input = document.querySelector('[name="file"]');

    if (input.files[0] != null) {
        let result = await readFile(input.files[0]);

        let str = ConvertArrayInStr(result);

 


        let fileName = input.files[0].name;
        let fileType = fileName.split('.');

        str += '.' + 'logo' + '.' + fileType[(fileType.length - 1)];

        fileBit.push(str);
    }
}

function ConvertArrayInStr(item) {
    var arrayBuffer = item,
        array = new Uint8Array(arrayBuffer);

    let fileByteArray = [];

    for (var i = 0; i < array.length; i++) {
        fileByteArray.push(array[i]);

    }

    return String(fileByteArray);
}