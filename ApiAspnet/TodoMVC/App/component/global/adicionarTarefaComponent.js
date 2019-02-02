// Comando 1
var data = {
    tarefas: [{ titulo: 'Teste titulo', descricao: 'Descricao', checked: true },
        { titulo: 'Teste titulo 2', descricao: 'Descricao', checked: false }],
    cabecalho: 'Suas tarefas',
    novoTitulo : '',
    novaDescricao: ''
};
// Comando 2
new Vue({
    el: '#tarefaId',
    data: data,
    methods: {
        addTarefa: function () {            
            var titulo = this.novoTitulo.trim();
            var descricao = this.novaDescricao.trim();
            if (titulo && descricao) {
                this.tarefas.push({
                    titulo: titulo,
                    descricao: descricao,
                    checked: false
                });
                this.novoTitulo = '';
                this.novaDescricao = '';
            }
        }
    }
});

