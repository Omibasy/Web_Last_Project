var swiper = new Swiper(".mySwiper", {
    direction: 'horizontal',
    loop: true,
    pagination: {
        el: '.swiper-pagination',
        clickable: true,
    },
    navigation: {
        nextEl: ".swiper-button-next",
        prevEl: ".swiper-button-prev",
    },
    allowTouchMove: false,
});

const lengthSlide = document.querySelectorAll(".swiper-slide").length;

function ChangingImage(input) {
    let [file] = input.files
    let blah = document.querySelector('.swiper-slide-active img');

    if (file) {
        blah.classList.remove('img--none')
        blah.src = URL.createObjectURL(file)

        
    }
    else {
        blah.classList.add('img--none')
    }

}

function ChangingBtn() {
    let blah = document.querySelector('.swiper-slide-active');
    blah.querySelector('input').click();
}


function RemoveSlade() {

    if (confirm('Вы уверенны, что хотите удалить данный слайд и слоган?')) {

        let slides = document.querySelectorAll(".swiper-slide");

        if (slides.length <= 1) {
            return;
        }

        let blah = document.querySelector('.swiper-slide-active');

        validateHero.removeField(`#${blah.querySelector('.swiper-slide__input').id}`);
        validateHero.removeField(`#${blah.querySelector('.hero__input-file').id}`);
        blah.remove();
        swiper.update();
    }
}

const validateHero = new JustValidate('#Form_HeroUpdata');

validateHero.addField('#Hero_title', [
    {
        rule: 'required',
        errorMessage: 'Поле заголовка не должно быть пустым',
    },
    {
        rule: 'customRegexp',
        value: /^[а-яА-Яa-zA-Z.,&?!()_\s\-]+$/gi,
        errorMessage: 'заголовка должен быть на русском или английском языке а также символы .,&?!()_'
    },
    {
        rule: 'minLength',
        value: 7,
        errorMessage: "в заголовке мало симвлов"
    },
    {
        rule: 'maxLength',
        value: 25,
        errorMessage: "в заголовке много символов"
    },

],
    {
        errorLabelStyle: {
            color: 'red',
            backgroundColor: 'white'
        }
    });

validateHero.addField('#Hero_btn', [
    {
        rule: 'required',
        errorMessage: 'Текст кнопки пуст',
    },
    {
        rule: 'minLength',
        value: 2,
        errorMessage: "мало символов"
    },
    {
        rule: 'maxLength',
        value: 15,
        errorMessage: "много символов"
    },
    {
        rule: 'customRegexp',
        value: /^[а-яА-Я\s]+$/gi,
        errorMessage: 'только русские буквы'
    },
],
    {
        errorLabelStyle: {
            color: 'red',
            backgroundColor: 'white'
        }
    });


validateHero.addField('#application__tittel', [
    {
        rule: 'required',
        errorMessage: 'закоголовок форы не должен быть пустым',
    },
    {
        rule: 'minLength',
        value: 7,
        errorMessage: "в закоголовоке форы мало сиволов"
    },
    {
        rule: 'maxLength',
        value: 40,
        errorMessage: "в закоголовоке форы много сиволов"
    },
    {
        rule: 'customRegexp',
        value: /^[а-яА-Я\s]+$/gi,
        errorMessage: 'закоголовок форы должен быть на русском языке'
    },
]);

validateHero.addField('#Name', [
    {
        rule: 'required',
        errorMessage: 'Поле имени не должно быть пустым',
    },
    {
        rule: 'minLength',
        value: 3,
        errorMessage: "Поле имени слишком маленькое"
    },
    {
        rule: 'maxLength',
        value: 25,
        errorMessage: "Поле имени слишком большое"
    },
    {
        rule: 'customRegexp',
        value: /^[а-яА-Я*\s!.,<>]+$/,
        errorMessage: 'Поле имени должно быть на русском языке'
    },
]);

validateHero.addField('#Email', [
    {
        rule: 'required',
        errorMessage: 'Поле Email не должно быть пустым',
    },
    {
        rule: 'minLength',
        value: 4,
        errorMessage: "Поле Email слишком маленькое"
    },
    {
        rule: 'maxLength',
        value: 20,
        errorMessage: "Поле Email слишком большое"
    },
    {
        rule: 'customRegexp',
        value: /^[а-яА-ЯA-Za-z*!.\s@,<>\-]+$/,
        errorMessage: 'Поле Email должно быть на русском языке'
    },
]);

validateHero.addField('#Text', [
    {
        rule: 'required',
        errorMessage: 'Поле сообщения не должно быть пустым',
    },
    {
        rule: 'minLength',
        value: 4,
        errorMessage: "Поле сообщения слишком маленькое"
    },
    {
        rule: 'maxLength',
        value: 22,
        errorMessage: "Поле сообщения слишком большое"
    },
    {
        rule: 'customRegexp',
        value: /^[а-яА-Я*!.,<>\s\-]+$/,
        errorMessage: 'Поле сообщения должно быть на русском языке'
    },
]);

validateHero.addField('#application_btn', [
    {
        rule: 'required',
        errorMessage: 'Текст кнопки пуст',
    },
    {
        rule: 'minLength',
        value: 2,
        errorMessage: "мало символов"
    },
    {
        rule: 'maxLength',
        value: 15,
        errorMessage: "много символов"
    },
    {
        rule: 'customRegexp',
        value: /^[а-яА-Я\s]+$/gi,
        errorMessage: 'только русские буквы'
    },
]);

function AddValidateInputSlideText() {
    let inpustText = document.querySelectorAll('.swiper-slide__input')

    for (item of inpustText) {


        validateHero.addField(`#${item.id}`, [
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
            },
        ],
            {
                errorLabelStyle: {
                    color: 'red',
                    backgroundColor: 'white'
                }
            });
    }

}

function AddValidateInputFile() {
    let inputsFile = document.querySelectorAll('.hero__input-file');

    for (item of inputsFile) {
        validateHero.addField(`#${item.id}`, [
            {
                rule: 'maxFilesCount',
                value: 1,
                errorMessage: 'не больше 1 файла'
            },
            {
                rule: 'files',
                value: {
                    files: {
                        extensions: ['jpeg', 'jpg', 'png'],
                        types: ['image/jpeg', 'image/jpg', 'image/png'],
                    }
                },
                errorMessage: 'файл должен быть формата jpeg, jpg, png'
            },
        ],
            {
                errorLabelStyle: {
                    color: 'red',
                    backgroundColor: 'white'
                }
            });
    }

}

AddValidateInputFile();
AddValidateInputSlideText();

function ConvertArrayInStr(item) {
    var arrayBuffer = item,
        array = new Uint8Array(arrayBuffer);

    let fileByteArray = [];

    for (var i = 0; i < array.length; i++) {
        fileByteArray.push(array[i]);

    }

    return String(fileByteArray);
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

async function SumbitForm(fileBit, slogans) {

    const inputs = document.querySelectorAll(".hero__input-file");

    let IdSlides = [];


    for (let i = 0; i < inputs.length; i++) {
        if (inputs[i].files[0] != null) {
            let result = await readFile(inputs[i].files[0]);

            let str = ConvertArrayInStr(result);
            let newFileName = slogans[i];

            if (newFileName.length > 8) {
                newFileName = newFileName.substring(0, 8);
            }

            let fileName = inputs[i].files[0].name;
            let fileType = fileName.split('.');

            str += '.' + newFileName + '.' + fileType[(fileType.length - 1)];

            fileBit.push(str);
        }

        let inputId = inputs[i].id.toString().split('_');

        let id = inputId[inputId.length - 1];

        IdSlides.push(id);
    }

    OnDeleteSlides(IdSlides, fileBit);
}

function OnDeleteSlides(IdSlides, fileBit)
{
    IdSlides = IdSlides.sort();

    let j = 0;

    for (i = 0; i < lengthSlide; i++) {
        let str = i.toString();

        if (str !== IdSlides[j]) {

            fileBit.push(str);
        }
        else {
            j++;
        }
    }

}


validateHero.onSuccess((event) => {

    let textInput = [];

    let slogans = [];

    let inputSlides = document.querySelectorAll('[name="slides"]');

   
    for (var item of inputSlides) {
        slogans.push(item.value);
    }

    SumbitForm(textInput, slogans).then((e) =>
    {

        $.ajax({
            type: "put",
            url: 'Update',
            headers: { "Accept": "application/json", "Content-Type": "application/json" },
            data: JSON.stringify(
                {
                    Title: document.querySelector('[name="HeroTitle"]').value,

                    Slogans: slogans,

                    BtnText: document.querySelector('[name="HeroBtn"]').value,

                    TitleForm: document.querySelector('[name="InputTitleForm"]').value,

                    PlaceholderName: document.querySelector('[name="InputName"]').value,

                    PlaceholderE_mail: document.querySelector('[name="InputEmail"]').value,
        
                    PlaceholderTextArea: document.querySelector('[name="InputText"]').value,

                    BtnForm: document.querySelector('[name="InputTextBtn"]').value,

                    files: textInput
                }  
            ),

            success: function (msg) {

                if (msg == 'successfully') {
                    window.location.href = "/Hero/IndexAdmin";
                }
                else {
                    window.location.href = "/Exception/Mistake";
                }
            }
        });
    });
});


