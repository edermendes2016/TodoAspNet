// Definindo novo componente chamado button-counter
Vue.component('button-counter', {
    data: function () {
        return {
            count: 0
        }
    },
    template: '<button v-on:click="count++">Você clicou em mim {{ count }} vezes.</button>'
})

new Vue({ el: '#components-demo' })