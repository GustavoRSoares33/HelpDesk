// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// Cole este código no final do arquivo site.js
function mostrarTela(telaId) {
    // Esconde todas as telas
    const telas = document.querySelectorAll('.container');
    telas.forEach(tela => tela.classList.remove('active'));

    // Mostra a tela selecionada
    document.getElementById(telaId).classList.add('active');
}