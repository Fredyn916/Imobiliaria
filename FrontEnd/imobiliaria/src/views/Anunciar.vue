<template>
    <form @submit.prevent="AddImoveis">
        <label for="tipoServico">Tipo de Serviço:</label>
        <input type="text" id="tipoServico" v-model="tipoServico" required />

        <label for="preco">Preço:</label>
        <input type="number" id="preco" v-model="preco" required />

        <label for="area">Área:</label>
        <input type="number" id="area" v-model="area" required />

        <label for="cep">CEP:</label>
        <input type="text" id="cep" v-model="cep" @blur="buscarCep" required />

        <label for="rua">Rua:</label>
        <input type="text" id="rua" v-model="rua" />

        <label for="anos">Anos:</label>
        <input type="text" id="anos" v-model="anos" />

        <label for="numero">Número:</label>
        <input type="number" id="numero" v-model="numero" required />

        <label for="bairro">Bairro:</label>
        <input type="text" id="bairro" v-model="bairro" />

        <label for="cidade">Cidade:</label>
        <input type="text" id="cidade" v-model="cidade" />

        <label for="unidadeFederativa">UF:</label>
        <input type="text" id="unidadeFederativa" v-model="unidadeFederativa" readonly />
        <button type="submit" class="btn-submit">Enviar Cadastro</button>
    </form>
</template>


<script>
export default {
    data() {
        return {
            selectedOption: '',
            tipoServico: this.selectedOption,
            preco: 0,
            area: 0,
            cep: '',
            rua: '',
            numero: '',
            bairro: '',
            cidade: '',
            unidadeFederativa: '',
            quartos: 0,
            suites: 0,
            banheiros: 0,
            vagas: 0,
            andar: 0,
            tipoNegocio: ''
        };
    },
    methods: {
        async buscarCep() {
            if (!this.cep || this.cep.length !== 8) {
                alert('CEP inválido');
                return;
            }

            try {
                const response = await fetch(`https://viacep.com.br/ws/${this.cep}/json/`);
                const data = await response.json();

                if (!data.erro) {
                    this.rua = data.logradouro;
                    this.bairro = data.bairro;
                    this.cidade = data.localidade;
                    this.unidadeFederativa = data.uf;
                } else {
                    alert('CEP não encontrado');
                }
            } catch (error) {
                alert('Erro ao buscar o CEP');
            }
        },

        async AddImoveis() {


            const data = {
                id: null,
                tipo: this.selectedOption,
                area: this.area,
                preco: this.preco,
                anos: this.anos,
                tipoServico: this.tipoServico,
                cep: this.cep,
                rua: this.rua,
                numero: this.numero,
                bairro: this.bairro,
                cidade: this.cidade,
                unidadeFederativa: this.unidadeFederativa,
                endereco: `${this.rua}, ${this.bairro}, ${this.cidade} - ${this.unidadeFederativa}`,
                urLsImagens: [],
                descricao: this.descricao,
                endereco: [`${this.quartos}, ${this.suites}, ${this.banheiros}, ${this.vagas}, - ${this.andar}`],
                tipoNegocio: this.tipoNegocio
            };

            const dataJson = JSON.stringify(data);
            console.log('Imóvel cadastrado: ', dataJson);

            try {
                const response = await fetch('https://localhost:7082/Imovel/AdicionarImovel', {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json' },
                    body: dataJson,
                });
                alert('Imóvel cadastrado com sucesso!');
            } catch (error) {
                console.error('Erro ao cadastrar imóvel: ', error);
                alert('Erro ao cadastrar imóvel');
            }
        }
    }
};
</script>
