

const validateProjectsCard = new JustValidate('#Form-services');

validateProjectsCard.addField('#textTitle', [
    {
        rule: 'required',
        errorMessage: 'Поле заголовка не должно быть пустым',
    },
    {
        rule: 'customRegexp',
        value: /^[а-яА-Яa-zA-Z0-9.,&?!()_\s\-]+$/gi,
        errorMessage: 'заголовка должен быть на русском или английском языке а также символы .,&?!()_'
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

