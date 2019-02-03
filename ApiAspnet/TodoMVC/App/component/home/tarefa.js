// Comando 1
var data = {
    tarefas: [{ titulo: 'Teste titulo', descricao: 'Descricao', checked: true },
    { titulo: 'Teste titulo 2', descricao: 'Descricao', checked: false }],
    cabecalho: 'Suas tarefas',
    novoTitulo: '',
    novaDescricao: ''
};

// Url da api
var UrlApi = 'http://localhost:15417/api/TodoItem';

new Vue({
    el: '#tarefaId',
    data() {
        return {            
            itens: []
        }
    },
    methods: {
        initialize() {
            // GET /Url
            this.$http.get(`${UrlApi}`).then(response => {

                // get body data
                this.itens = response.body;
                console.log(this.itens);

            }, response => {
                // error callback
            });
        }
    },
    created() {
        this.initialize()
    }
})

// Comando 2
//new Vue({
//    el: '#tarefaId',
//    data: data,
//    methods: {
//        addTarefa: function () {
//            var titulo = this.novoTitulo.trim();
//            var descricao = this.novaDescricao.trim();
//            if (titulo && descricao) {
//                this.tarefas.push({
//                    titulo: titulo,
//                    descricao: descricao,
//                    checked: false
//                });
//                this.novoTitulo = '';
//                this.novaDescricao = '';
//            }
//        }
//    }
//});

