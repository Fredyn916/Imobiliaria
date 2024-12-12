<template>
    <div class="container">
        <div class="Etapas">
            <p class="Etapa" :class="{ 'escuro': step === 1 }">Tipo de Imóvel</p>
            <p class="Etapa" :class="{ 'escuro': step === 2 }">Localização</p>
            <p class="Etapa" :class="{ 'escuro': step === 3 }">Características</p>
        </div>

        <div class="internal__container">
            <div class="container__tittle">
                <h1>Vamos começar a montar seu anúncio!</h1>
            </div>
            <div class="add__imoveis__box">
                <form @submit.prevent="PostImovel">
                    <!-- Etapa 1 -->
                    <div v-if="step === 1">
                        <h3 class="h3">Diga qual tipo de operaçao deseja realizar</h3>
                        <div class="select__status">
                            <label for="status">Tipo de operação</label>
                            <div class="internal__select__status">
                                <button type="button" class="select__status-btn"
                                    :class="{ active: selectedStatus === 'Comprar' }"
                                    @click="selectedStatus = 'Comprar'">
                                    Venda
                                </button>
                                <button type="button" class="select__status-btn"
                                    :class="{ active: selectedStatus === 'Alugar' }" @click="selectedStatus = 'Alugar'">
                                    Aluguel
                                </button>
                            </div>
                        </div>

                        <label for="status">Tipo de Imóvel</label>
                        <select v-model="selectedProperty" class="property__select">
                            <option value="">Selecione um tipo de imóvel</option>
                            <option value="Apartamento">Apartamento</option>
                            <option value="Casa">Casa</option>
                            <option value="Comercial">Comercial</option>
                            <option value="Lote">Lote</option>
                            <option value="Rural">Rural</option>
                            <option value="Terreno">Terreno</option>
                        </select>

                        <button type="button" @click="nextStep" :disabled="!selectedProperty || !selectedStatus">
                            Próxima Etapa
                        </button>
                    </div>

                    <!-- Etapa 2 -->
                    <div v-if="step === 2" class="step2">

                        <div class="Collun">
                            <h2>Detalhes do Imóvel</h2>

                            <div class="Step2__container">
                                <div class="Step2__item">
                                    <label for="anos">Idade do Imovel</label>
                                    <input type="text" id="anos" v-model="anos" />

                                    <label for="cep">CEP</label>
                                    <input type="text" id="cep" v-model="cep" @blur="buscarCep" />

                                    <label for="rua">Rua</label>
                                    <input type="text" id="rua" v-model="rua" />

                                    <label for="numero">Número</label>
                                    <input type="text" id="numero" v-model="numero" />
                                </div>


                                <div class="Step2__item">

                                    <label for="unidadeFederativa">Estado</label>
                                    <input type="text" id="unidadeFederativa" v-model="unidadeFederativa" />

                                    <label for="cidade">Cidade</label>
                                    <input type="text" id="cidade" v-model="cidade" />

                                    <label for="bairro">Bairro</label>
                                    <input type="text" id="bairro" v-model="bairro" />

                                    <div class="form-group">
                                        <label for="image">Fotos do Imóvel:</label>
                                        <input type="file" id="image" @change="handleFileUpload" />
                                    </div>

                                </div>
                            </div>
                            <button type="button" @click="nextStep">Próxima Etapa</button>
                            <button type="button" @click="prevStep">Voltar</button>
                        </div>
                    </div>

                    <!-- Etapa 3 -->
                    <div v-if="step === 3" class="step3">
                        <h2>Informações Adicionais</h2>
                        <div class="property__inputs">
                            <div class="counter__group">
                                <div class="counter">
                                    <label>Quartos</label>
                                    <div class="counter__controls">
                                        <button type="button" @click="quartos = Math.max(quartos - 1, 0)">-</button>
                                        <input type="number" v-model="quartos" readonly />
                                        <button type="button" @click="quartos++">+</button>
                                    </div>
                                </div>
                                <div class="counter">
                                    <label>Banheiros</label>
                                    <div class="counter__controls">
                                        <button type="button" @click="banheiros = Math.max(banheiros - 1, 0)">-</button>
                                        <input type="number" v-model="banheiros" readonly />
                                        <button type="button" @click="banheiros++">+</button>
                                    </div>
                                </div>
                                <div class="counter">
                                    <label>Garagens</label>
                                    <div class="counter__controls">
                                        <button type="button" @click="garagens = Math.max(garagens - 1, 0)">-</button>
                                        <input type="number" v-model="garagens" readonly />
                                        <button type="button" @click="garagens++">+</button>
                                    </div>
                                </div>
                            </div>

                            <div class="area__group">
                                <label>Área (m²):</label>
                                <input type="number" v-model="area" />

                                <label>Valor (R$):</label>
                                <input type="text" v-model="preco" />
                            </div>
                        </div>

                        <label for="titulo">Título:</label>
                        <input type="text" id="titulo" v-model="titulo" required />

                        <label for="descricao">Descrição:</label>
                        <textarea id="descricao" v-model="descricao"></textarea>

                        <button type="button" @click="prevStep">Voltar</button>
                        <button type="submit">Anunciar</button>
                    </div>
                </form>
            </div>
        </div>
    </div>
</template>

<script>export default {
    name: "AnunciarSeuImovel",
    data() {
        return {
            step: 1,
            selectedStatus: "",
            selectedProperty: "",
            anos: 0,
            cep: "",
            rua: "",
            numero: 0,
            unidadeFederativa: "",
            cidade: "",
            bairro: "",
            quartos: 0,
            banheiros: 0,
            garagens: 0,
            area: 0,
            preco: "",
            titulo: "",
            descricao: "",
            selectedFile: null,
        };
    },
    methods: {
        handleFileUpload(event) {
            this.selectedFile = event.target.files[0];
        },
        nextStep() {
            if (this.step < 3) this.step++;
        },
        prevStep() {
            if (this.step > 1) this.step--;
        },

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
        async PostImovel(e) {
            e.preventDefault();
            const data = {
                id: null, // Campo opcional, substitua conforme necessário
                tipo: this.selectedProperty || "string",
                area: this.area || 0,
                preco: parseFloat(this.preco) || 0,
                anos: this.anos || 0,
                tipoServico: this.selectedStatus || "string",
                cep: this.cep || "string",
                rua: this.rua || "string",
                numero: parseInt(this.numero) || 0,
                bairro: this.bairro || "string",
                cidade: this.cidade || "string",
                unidadeFederativa: this.unidadeFederativa || "string",
                endereco: `${this.rua}, ${this.numero}, ${this.bairro}, ${this.cidade}, ${this.unidadeFederativa}` || "string",
                urLsImagens: [], // Substitua após implementar o upload de imagens
                titulo: this.titulo || "string",
                descricao: this.descricao || "string",
                areasComuns: [
                    `Quartos: ${this.quartos}`,
                    `Banheiros: ${this.banheiros}`,
                    `Garagens: ${this.garagens}`,
                ],
            };
            const dataJson = JSON.stringify(data)
            console.log(data)

            const response = await fetch('https://localhost:7082/Imovel/AdicionarImovel', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: dataJson
            });

            const responseData = await response.json();
            const responseID = responseData.id;

            const formData = new FormData();
            formData.append("imagem", this.selectedFile);

            const responsePostImagem = await fetch(`https://localhost:7082/Imovel/UploadImage?imovelId=${responseID}`, {
                method: "PUT",
                body: formData,
            });

        },
    },
};

</script>


<style scoped>
.container {
    display: flex;
    align-items: center;
    padding: 20px;
    font-family: "Funnel Display", sans-serif;
    background-color: #FFF;
    height: auto;
    max-height: 200vh;
}

.Etapas {
    background-color: rgb(243, 247, 248);
    border-radius: 10px;
    height: auto;
    min-height: 130px;
    width: 300px;
    padding: 10px;
}

.Etapa {
    color: #888;
    font-weight: normal;
    height: 30%;
    min-height: 50px;
    display: flex;
    align-items: center;
    justify-content: center;
    padding: 20px;
}

.Etapa.escuro {
    color: #333;
    background-color: #ededed;
    font-weight: bold;
    border-radius: 10px;
    border: 1px solid #333;
}


.internal__container {
    width: 100%;
    display: flex;
    flex-direction: column;
    text-align: center;
    align-items: center;
    justify-content: center;
}

.container__tittle {
    width: 100%;
    height: 120px;
    display: flex;
    justify-content: center;
    align-items: center;

}

label {
    color: #333;
    font-weight: 600;
}

.add__imoveis__box {
    width: 100%;
    max-width: 900px;
    height: auto;
    padding: 40px 40px 20px;
    background-color: #ffffff;
    border-radius: 8px;
    box-shadow: rgba(0, 0, 0, 0.08) -1px 2px 20px 0px;
    margin-top: 20px;
    text-align: left;
}

h1,
h2,
h3 {
    color: #333;
    text-align: left;
}

.h3 {
    padding-bottom: 20px;
}

.select__status {
    display: flex;
    flex-direction: column;
    justify-content: space-between;
    margin-bottom: 20px;
    height: 60px;
}

.internal__select__status {
    width: 100%;
    height: 100%;
    display: flex;
    text-align: left;
    justify-content: space-around;
}

.select__status-btn {
    flex: 1;
    margin: 0 5px;
    padding: 15px;
    font-size: 16px;
    color: white;
    border: 1px solid #ddd;
    border-radius: 10px;
    background-color: rgb(0, 43, 82);
    cursor: pointer;
    transition: 0.3s;
}

.select__status-btn.active {
    background-color: #FFF;
    border: 3px solid rgb(0, 43, 82);
    color: #000;
    transform: scale(1.1);
}

.property__select {
    width: 100%;
    padding: 10px;
    margin: 20px 0;
    border: 2px solid #ddd;
    border-radius: 10px;
    font-size: 14px;
}

button {
    padding: 10px 20px;
    margin: 10px 0;
    background-color: rgb(0, 43, 82);
    color: white;
    border: none;
    border-radius: 4px;
    cursor: pointer;
    transition: 0.3s;
    width: 100%;
}

button:disabled {
    background-color: #ccc;
    cursor: not-allowed;
}

button:hover {
    background-color: #1A5276;
    transform: scale(1.05);
}



.property__inputs {
    display: flex;
    flex-direction: column;
    gap: 2rem;
}

.counter__group,
.area__group {
    display: flex;
    flex-wrap: wrap;
    gap: 1.5rem;
}

.counter,
.area-input {
    display: flex;
    flex-direction: column;
    width: 200px;
}

.counter__controls {
    display: flex;
    align-items: center;
    gap: 0.5rem;
}

.counter__controls button {
    width: 40px;
    height: 40px;
    background-color: #1A5276;
    color: white;
    border: none;
    border-radius: 4px;
    font-size: 18px;
    font-weight: bold;
    cursor: pointer;
    transition: background-color 0.3s ease;
}

.counter__controls button:hover {
    background-color: #154360;
}

.property__inputs input[type="number"] {
    width: 60px;
    text-align: center;
    border: 1px solid #ddd;
    border-radius: 4px;
    font-size: 16px;
    padding: 5px;
}

.property__inputs input[type="text"] {
    width: 60px;
    text-align: center;
    border: 1px solid #ddd;
    border-radius: 4px;
    font-size: 16px;
    padding: 5px;
}

.input-wrapper {
    display: flex;
    align-items: center;
    gap: 0.5rem;
}

.property__inputs span {
    font-size: 1rem;
}

.step2 {
    display: flex;
    font-weight: bold;
    align-items: center;
    justify-content: center;
}

.Step2__container {
    display: flex;
    gap: 20px;
}

.Step2__item {
    flex: 1;
    display: flex;
    flex-direction: column;
}

.step2 input {
    border: 2px solid #ededed;
    border-radius: 7px;
    margin-top: 13px;
    padding: 1rem;
}

.step3 {
    display: flex;
    flex-direction: column;
}

.step3 input,
textarea {
    border: 3px solid #ededed;
    border-radius: 7px;
    margin-top: 13px;
    padding: 1rem;
}

@media (max-width: 1200px) {
    .container {
        flex-direction: column;
        padding: 15px;
    }

    .Etapas {
        width: 90%;
    }

    .add__imoveis__box {
        width: 100%;
        padding: 20px;
    }
}

@media (max-width: 992px) {
    .internal__container {
        padding: 10px;
    }

    .select__status-btn {
        font-size: 14px;
    }

    .property__select,
    button,
    .property__inputs input[type="number"],
    .property__inputs input[type="text"] {
        width: 100%;
    }

    .step2 {
        flex-direction: column;
    }

    .Step2__container {
        flex-direction: column;
    }

    .counter__controls button {
        width: 35px;
        height: 35px;
    }
}

@media (max-width: 768px) {
    .container {
        height: auto;
        max-height: none;
    }

    .Etapas {
        width: 100%;
    }

    .add__imoveis__box {
        height: auto;
        padding: 15px;
    }

    .select__status-btn {
        font-size: 14px;
        margin: 5px 0;
    }

    .property__select {
        padding: 8px;
    }

    .counter__group,
    .area__group {
        flex-direction: column;
        gap: 1rem;
    }

    .counter,
    .area-input {
        width: 100%;
    }

    .input-wrapper {
        flex-direction: column;
        align-items: flex-start;
    }

    .step3 input,
    .step3 textarea {
        padding: 0.8rem;
    }
}

@media (max-width: 480px) {
    .container {
        padding: 10px;
    }

    .Etapas {
        width: 100%;
        padding: 10px;
    }

    .add__imoveis__box {
        padding: 10px;
    }

    h1,
    h2,
    h3 {
        font-size: 18px;
    }

    .select__status-btn {
        padding: 10px;
        font-size: 12px;
    }

    .property__select,
    .property__inputs input[type="number"],
    .property__inputs input[type="text"],
    button {
        font-size: 14px;
    }

    .counter__controls button {
        width: 30px;
        height: 30px;
    }
}
</style>
