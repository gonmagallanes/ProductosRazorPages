let cardCostos = document.getElementById("cardCostos")
let cardArticulo = document.getElementById("cardArticulo")

cardCostos.addEventListener("click", () => redirectToProducts())
cardArticulo.addEventListener("click", () => redirectToCreateCategory())

function redirectToProducts() {
    window.location.href = '/Productos/IndexProductos';
}

function redirectToCreateCategory() {
    window.location.href = '/Categorias/CreateCategoria';
}

document.addEventListener("DOMContentLoaded", () => {
    const title = document.querySelector("h1");
    title.addEventListener("mouseenter", () => {
        title.classList.add("wiggle");
        setTimeout(() => title.classList.remove("wiggle"), 1000);
    });
});
