<template>
    <div class="container">
        <h2>Cadastro de Imóvel</h2>
        <select v-model="selectedOption" id="propertyType" class="form-control">
            <option value="" disabled>Selecione um tipo de imóvel</option>
            <option value="Apartamento">Apartamento</option>
            <option value="Casa">Casa</option>
            <option value="Comercial">Comercial</option>
            <option value="Rural">Rural</option>
            <option value="Lote">Lote</option>
            <option value="Terreno">Terreno</option>
        </select>
        <div v-if="selectedOption" class="form-container">
            <form @submit.prevent="AddImoveis" class="form-left">
                <div class="form-group">
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
                </div>
                <button type="submit" class="btn-submit">Enviar Cadastro</button>
            </form>

            <div class="form-right">
                <div class="form-group" v-if="selectedOption === 'Apartamento' || selectedOption === 'Casa' || selectedOption === 'Rural'">
                    <label for="quartos">Quartos:</label>
                    <input type="number" id="quartos" v-model="quartos" />

                    <label for="suites">Suítes:</label>
                    <input type="number" id="suites" v-model="suites" />

                    <label for="banheiros">Banheiros:</label>
                    <input type="number" id="banheiros" v-model="banheiros" />

                    <label for="vagas">Vagas:</label>
                    <input type="number" id="vagas" v-model="vagas" />

                    <label v-if="selectedOption === 'Apartamento'" for="andar">Andar:</label>
                    <input v-if="selectedOption === 'Apartamento'" type="number" id="andar" v-model="andar" />
                </div>

                <div class="form-group" v-if="selectedOption === 'Comercial'">
                    <label for="banheiros">Banheiros:</label>
                    <input type="number" id="banheiros" v-model="banheiros" />

                    <label for="vagas">Vagas:</label>
                    <input type="number" id="vagas" v-model="vagas" />

                    <label for="tipoNegocio">Tipo de Negócio:</label>
                    <input type="text" id="tipoNegocio" v-model="tipoNegocio" />
                </div>

                <div v-if="selectedOption === 'Lote' || selectedOption === 'Terreno'" class="form-group">
                    <p>{{ selectedOption }} não possuem campos específicos.</p>
                </div>
            </div>
        </div>
    </div>
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

<style scoped>
.container {
    display: flex;
    flex-direction: column;
    align-items: center;
    max-width: 1000px;
    margin: 0 auto;
    padding: 20px;
}

.form-control {
    width: 50%;
    padding: 10px;
    margin-bottom: 20px;
    border-radius: 5px;
    border: 1px solid #ccc;
}

.form-container {
    display: flex;
    justify-content: space-between;
    width: 100%;
}

.form-left,
.form-right {
    flex: 1;
    padding: 20px;
    box-shadow: 0px 4px 8px rgba(0, 0, 0, 0.1);
    border-radius: 10px;
    background: #f9f9f9;
    margin: 10px;
}

.form-group {
    display: flex;
    flex-direction: column;
    gap: 15px;
}

input {
    padding: 8px;
    font-size: 16px;
    border-radius: 5px;
    border: 1px solid #ccc;
}

.btn-submit {
    padding: 10px;
    background-color: rgb(0, 43, 82);
    color: white;
    border: none;
    cursor: pointer;
    font-size: 16px;
    border-radius: 5px;
    transition: background 0.3s;
}

.btn-submit:hover {
    background-color: #1A5276;
}
</style>