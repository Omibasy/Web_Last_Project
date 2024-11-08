function ChangingImage(input) {
    let [file] = input.files
    let blah = document.querySelector('#blah');
    let spanSvg = document.querySelector('#span__svg-castom');

    if (file) {
        blah.classList.remove('img--none')
        spanSvg.classList.add('img--none');
        blah.src = URL.createObjectURL(file)
    }
    else {
        blah.classList.add('img--none');
        spanSvg.classList.remove('img--none');
    }
}


const validateHeroAdd = new JustValidate('#Form_HeroAddSlide');

validateHeroAdd.addField('#text-slider', [
    {
        rule: 'required',
        errorMessage: 'Поле слогана не должно быть пустым',
    },
    {
        rule: 'minLength',
        value: 7,
        errorMessage: "Поле слогана слишком маленькое"
    },
    {
        rule: 'maxLength',
        value: 32,
        errorMessage: "Поле слогана слишком большое"
    },
    {
        rule: 'customRegexp',
        value: /^[а-яА-Я\s0-9]+$/,
        errorMessage: 'Поле слогана должно быть на русском языке'
    }]);


validateHeroAdd.addField('#file_hero_add', [
    {
        rule: 'maxFilesCount',
        value: 1,
        errorMessage: 'Не больше 1 картинки'
    },
    {
        rule: 'minFilesCount',
        value: 1,
        errorMessage: 'Ни одна картинка не выбрана'
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
    }
]);

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

function ConvertArrayInStr(item) {
    var arrayBuffer = item,
        array = new Uint8Array(arrayBuffer);

    let fileByteArray = [];

    for (var i = 0; i < array.length; i++) {
        fileByteArray.push(array[i]);

    }

    return String(fileByteArray);
}


async function SumbitForm(fileBit, slide_text) {

    const input = document.querySelector("#file_hero_add");

    if (input.files[0] != null) {
        let result = await readFile(input.files[0]);

        let str = ConvertArrayInStr(result);

        if (slide_text.length > 8) {
            slide_text = slide_text.substring(0, 8);
        }

        let fileName = input.files[0].name;
        let fileType = fileName.split('.');

        str += '.' + slide_text + '.' + fileType[(fileType.length - 1)];

        fileBit.push(str);
    }
}




validateHeroAdd.onSuccess(event => {

    let fileBit = [];
    let slide_text = document.querySelector("#text-slider").value;

    SumbitForm(fileBit, slide_text).then((e) => {
        

        $.ajax({
            type: "post",
            url: 'Set',
            headers: { "Accept": "application/json", "Content-Type": "application/json" },
            data: JSON.stringify(
                {
                    fileBit: fileBit[0],
                    slideText: slide_text
                }
            ),

            success: function (msg) {


                if (msg == 'successfully') {
                    window.location.href = "/Hero/IndexAdmin";
                }
                else
                {
                    window.location.href = "/Exception/Mistake";
                }
 
            }
        });


    });

   
});