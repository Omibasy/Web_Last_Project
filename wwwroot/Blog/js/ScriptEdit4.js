const validateProjectsCard = new JustValidate('#Form-blog');

validateProjectsCard.addField('#file', [
    {
        rule: 'minFilesCount',
        value: 1,
        errorMessage: 'Выберите файл'
    },
    {
        rule: 'maxFilesCount',
        value: 1,
        errorMessage: 'Не больше 1 файла'
    },
    {
        rule: 'files',
        value: {
            files: {
                extensions: ['jpeg', 'jpg', 'png'],
                types: ['image/jpeg', 'image/jpg', 'image/png'],
            }
        },
        errorMessage: 'Файл должен быть формата jpeg, jpg, png'
    },
]);

validateProjectsCard.addField('#textTitle', [
    {
        rule: 'required',
        errorMessage: 'Поле заголовка не должно быть пустым',
    },
    {
        rule: 'customRegexp',
        value: /^[а-яА-Яa-zA-Z0-9.,:;&?!()_\s\-]+$/gi,
        errorMessage: 'заголовка должен быть на русском или английском языке а также символы .,&:;?!()_'
    },
    {
        rule: 'minLength',
        value: 7,
        errorMessage: "В заголовке мало симвлов"
    },
    {
        rule: 'maxLength',
        value: 70,
        errorMessage: "В заголовке много символов"
    }
]);

validateProjectsCard.addField('#textDescrit', [
    {
        rule: 'required',
        errorMessage: 'Поле текста не должно быть пустым',
    },
    {
        rule: 'minLength',
        value: 7,
        errorMessage: "В тексте мало симвлов"
    }
]);

validateProjectsCard.addField('#DateCardEdit', [

    {
        plugin: JustValidatePluginDate(() => ({
            required: true,
            isAfter: '01/01/2010',

        })),
        errorMessage: 'Укажите дату не поже (01.01.2010)',
    },


]);

validateProjectsCard.onSuccess(event => {

    let fileBit = [];
    let str = window.location.href.split('=');
    let coutn = str[str.length - 1];

    SumbitForm(fileBit).then((e) => {

        if (fileBit.length < 1) {
            fileBit.push("");
        }

        $.ajax({
            type: "put",
            url: 'Edit',
            headers: { "Accept": "application/json", "Content-Type": "application/json" },
            data: JSON.stringify(
                {
                    dateTime: document.querySelector('#DateCardEdit').value,
                    Alt: coutn,
                    Description: document.querySelector('#textDescrit').value,
                    Title: document.querySelector('#textTitle').value,
                    file: fileBit[0]
                }
            ),

            success: function (msg) {

                if (msg == 'successfully') {
                    window.location.href = "/Blog/Editable";
                }
                else {
                    window.location.href = "/Exception/Mistake";
                }
            }
        });
    });
});


function ChangingImage(input) {


    let [file] = input.files
    let blah = document.querySelector('#blah');
    let plus = document.querySelector('#plus');

    if (file) {
        blah.classList.remove('img--none')
        plus.classList.add('img--none')
        blah.src = URL.createObjectURL(file)
    }
    else {
        plus.classList.remove('img--none')
        blah.classList.add('img--none')
    }

}

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

    let title = document.getElementById('blah').getAttribute('alt');

    if (input.files[0] != null) {
        let result = await readFile(input.files[0]);

        let str = ConvertArrayInStr(result);

        let fileName = input.files[0].name;
        let fileType = fileName.split('.');

        str += '.' + title + '.' + fileType[(fileType.length - 1)];

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