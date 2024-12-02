window.onload = function () {
    // Define a função previewImage após o carregamento da página
    window.previewImage = function (input) {
        if (input.files && input.files[0]) {
            var reader = new FileReader();

            reader.onload = function (e) {
                var imgElement = document.getElementById('img1');
                if (imgElement) {
                    imgElement.src = e.target.result;
                } else {
                    console.error("Elemento img1 não encontrado. Verifique o ID.");
                }
            };

            reader.readAsDataURL(input.files[0]);
        } else {
            console.error("Nenhum arquivo selecionado.");
        }
    };
};