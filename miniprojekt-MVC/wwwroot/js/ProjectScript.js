let btn = document.querySelector("#create-project")

btn.addEventListener('click', (e) => {
    e.preventDefault()
    let form = document.querySelector("#create-form")
    form.classList.remove("visually-hidden")
})