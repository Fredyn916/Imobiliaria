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
                        vagas        </div>
                                <div class="counter">
                                    <label>Banheiros</label>
                                    <div class="counter__controls">
                                        <button type="button" @click="banheiros = Math.max(banheiros - 1, 0)">-</button>
                                        <input type="number" v-model="banheiros" readonly />
                                        <button type="button" @click="banheiros++">+</button>
                                    </div>
                                </div>
                                <div class="counter">
                                    <label>vagas</label>
                                    <div class="counter__controls">
                                        <button type="button" @click="vagas = Math.max(vagas - 1, 0)">-</button>
                                        <input type="number" v-model="vagas" readonly />
                                        <button type="button" @click="vagas++">+</button>
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
            vagas: 0,
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
                    `vagas: ${this.vagas}`,
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
            const UsuarioId = responseData.id;

            if (response.status === 200) {
                this.PostImage(UsuarioId);
            } else {
                this.message = 'Erro ao cadastrar o usuário.';
            }

        },

        PostImage(UsuarioId) {
            if (!this.selectedFile) {
                this.message = 'Por favor, selecione uma imagem antes de enviar.';
                return;
            }

            const formData = new FormData();
            formData.append("imagem", this.selectedFile);

            try {
                const responsePostImagem = fetch(`https://localhost:7082/Imovel/UploadImage?imovelId=${UsuarioId}`, {
                    method: "PUT",
                    body: formData,
                });

                if (responsePostImagem.status === 200) {
                    this.message = 'Imagem carregada com sucesso!';
                } else {
                    this.message = 'Erro ao carregar a imagem.';
                }
            } catch (error) {
                console.error('Erro ao enviar imagem:', error);
                this.message = 'Erro ao tentar enviar a imagem.';
            }
        },
    },
};

</script>
<style scoped>
.container {
    display: flex;
    /* Utiliza Flexbox para layout flexível */
    align-items: center;
    /* Alinha os itens verticalmente ao centro */
    padding: 20px;
    /* Adiciona padding interno de 20px em todos os lados */
    font-family: "Funnel Display", sans-serif;
    /* Define a fonte da página */
    background-color: #FFF;
    /* Define o fundo branco */
    height: auto;
    /* A altura é ajustada automaticamente conforme o conteúdo */
    max-height: 200vh;
    /* Define uma altura máxima de 200% da altura da tela */
}

.Etapas {
    background-color: rgb(243, 247, 248);
    /* Define o fundo em um tom claro de cinza */
    border-radius: 10px;
    /* Borda arredondada */
    height: auto;
    /* A altura se ajusta conforme o conteúdo */
    min-height: 130px;
    /* Altura mínima de 130px */
    width: 300px;
    /* Largura fixa de 300px */
    padding: 10px;
    /* Padding interno de 10px */
}

.Etapa {
    color: #888;
    /* Cor do texto em cinza claro */
    font-weight: normal;
    /* Peso da fonte normal */
    height: 30%;
    /* Altura da Etapa é 30% do seu container */
    min-height: 50px;
    /* Altura mínima de 50px */
    display: flex;
    /* Utiliza Flexbox para alinhamento */
    align-items: center;
    /* Alinha os itens verticalmente ao centro */
    justify-content: center;
    /* Alinha os itens horizontalmente ao centro */
    padding: 20px;
    /* Padding interno de 20px */
}

.Etapa.escuro {
    color: #333;
    /* Cor do texto em cinza escuro */
    background-color: #ededed;
    /* Cor de fundo cinza claro */
    font-weight: bold;
    /* Peso da fonte em negrito */
    border-radius: 10px;
    /* Borda arredondada */
    border: 1px solid #333;
    /* Borda de 1px e cor cinza escuro */
}

.internal__container {
    width: 100%;
    /* A largura é 100% do elemento pai */
    display: flex;
    /* Flexbox para layout flexível */
    flex-direction: column;
    /* Organiza os itens em uma coluna */
    text-align: center;
    /* Alinha o texto no centro */
    align-items: center;
    /* Alinha os itens no centro horizontal */
    justify-content: center;
    /* Alinha os itens no centro vertical */
}

.container__tittle {
    width: 100%;
    /* A largura é 100% do elemento pai */
    height: 120px;
    /* Altura fixa de 120px */
    display: flex;
    /* Flexbox para layout flexível */
    justify-content: center;
    /* Alinha os itens horizontalmente no centro */
    align-items: center;
    /* Alinha os itens verticalmente no centro */
}

label {
    color: #333;
    /* Cor do texto em cinza escuro */
    font-weight: 600;
    /* Peso da fonte em semi-negrito */
}

.add__imoveis__box {
    width: 100%;
    /* A largura ocupa 100% do seu container */
    max-width: 900px;
    /* Largura máxima de 900px */
    height: auto;
    /* Altura ajustada automaticamente */
    padding: 40px 40px 20px;
    /* Padding de 40px nas laterais e 20px na parte inferior */
    background-color: #ffffff;
    /* Cor de fundo branca */
    border-radius: 8px;
    /* Bordas arredondadas */
    box-shadow: rgba(0, 0, 0, 0.08) -1px 2px 20px 0px;
    /* Sombra suave ao redor */
    margin-top: 20px;
    /* Margem superior de 20px */
    text-align: left;
    /* Alinha o texto à esquerda */
}

h1,
h2,
h3 {
    color: #333;
    /* Cor do texto em cinza escuro */
    text-align: left;
    /* Alinha o texto à esquerda */
}

.h3 {
    padding-bottom: 20px;
    /* Padding inferior de 20px */
}

.select__status {
    display: flex;
    /* Flexbox para layout flexível */
    flex-direction: column;
    /* Organiza os itens em uma coluna */
    justify-content: space-between;
    /* Espaça os itens igualmente */
    margin-bottom: 20px;
    /* Margem inferior de 20px */
    height: 60px;
    /* Altura fixa de 60px */
}

.internal__select__status {
    width: 100%;
    /* A largura ocupa 100% do seu container */
    height: 100%;
    /* A altura ocupa 100% do seu container */
    display: flex;
    /* Flexbox para layout flexível */
    text-align: left;
    /* Alinha o texto à esquerda */
    justify-content: space-around;
    /* Espaça os itens igualmente */
}

.select__status-btn {
    flex: 1;
    /* Flexível, ocupando 1 unidade de espaço */
    margin: 0 5px;
    /* Margem lateral de 5px */
    padding: 15px;
    /* Padding interno de 15px */
    font-size: 16px;
    /* Tamanho da fonte de 16px */
    color: white;
    /* Cor do texto em branco */
    border: 1px solid #ddd;
    /* Borda fina cinza claro */
    border-radius: 10px;
    /* Bordas arredondadas */
    background-color: rgb(0, 43, 82);
    /* Cor de fundo azul */
    cursor: pointer;
    /* Altera o cursor para ponteiro */
    transition: 0.3s;
    /* Transição suave de 0.3 segundos */
}

.select__status-btn.active {
    background-color: #FFF;
    /* Altera o fundo para branco quando ativo */
    border: 3px solid rgb(0, 43, 82);
    /* Borda azul mais espessa quando ativo */
    color: #000;
    /* Cor do texto preto */
    transform: scale(1.1);
    /* Aumenta o tamanho ao ser ativo */
}

.property__select {
    width: 100%;
    /* A largura ocupa 100% do seu container */
    padding: 10px;
    /* Padding interno de 10px */
    margin: 20px 0;
    /* Margem de 20px na parte superior e inferior */
    border: 2px solid #ddd;
    /* Borda fina cinza claro */
    border-radius: 10px;
    /* Bordas arredondadas */
    font-size: 14px;
    /* Tamanho da fonte de 14px */
}

button {
    padding: 10px 20px;
    /* Padding de 10px nas laterais e 20px no comprimento */
    margin: 10px 0;
    /* Margem de 10px na parte superior e inferior */
    background-color: rgb(0, 43, 82);
    /* Cor de fundo azul escuro */
    color: white;
    /* Cor do texto em branco */
    border: none;
    /* Sem borda */
    border-radius: 4px;
    /* Bordas arredondadas */
    cursor: pointer;
    /* Altera o cursor para ponteiro */
    transition: 0.3s;
    /* Transição suave de 0.3 segundos */
    width: 100%;
    /* Largura do botão ocupa 100% do container */
}

button:disabled {
    background-color: #ccc;
    /* Cor de fundo cinza para botões desabilitados */
    cursor: not-allowed;
    /* Cursor alterado para "não permitido" */
}

button:hover {
    background-color: #1A5276;
    /* Cor de fundo azul mais claro ao passar o mouse */
    transform: scale(1.05);
    /* Aumenta o tamanho do botão */
}

/* Seletor de inputs de propriedades */
.property__inputs {
    display: flex;
    /* Flexbox para layout flexível */
    flex-direction: column;
    /* Organiza os itens em uma coluna */
    gap: 2rem;
    /* Espaço de 2rem entre os itens */
}

/* Grupos de controles numéricos e área */
.counter__group,
.area__group {
    display: flex;
    /* Flexbox para layout flexível */
    flex-wrap: wrap;
    /* Permite quebra de linha */
    gap: 1.5rem;
    /* Espaço de 1.5rem entre os itens */
}

.counter,
.area-input {
    display: flex;
    /* Flexbox para layout flexível */
    flex-direction: column;
    /* Organiza os itens em uma coluna */
    width: 200px;
    /* Largura fixa de 200px */
}

.counter__controls {
    display: flex;
    /* Flexbox para controles numéricos */
    align-items: center;
    /* Alinha os controles ao centro verticalmente */
    gap: 0.5rem;
    /* Espaço de 0.5rem entre os controles */
}

.counter__controls button {
    width: 40px;
    /* Largura de 40px para os botões */
    height: 40px;
    /* Altura de 40px para os botões */
    background-color: #1A5276;
    /* Cor de fundo azul escuro */
    color: white;
    /* Cor do texto branco */
    border: none;
    /* Sem borda */
    border-radius: 4px;
    /* Bordas arredondadas */
    font-size: 18px;
    /* Tamanho da fonte de 18px */
    font-weight: bold;
    /* Fonte em negrito */
    cursor: pointer;
    /* Cursor de ponteiro */
    transition: background-color 0.3s ease;
    /* Transição suave da cor de fundo */
    display: flex;
    align-items: center;
    /* Alinha os itens na horizontal */
    justify-content: center;
    /* Alinha os itens na vertical */
}

.counter__controls button:hover {
    background-color: #154360;
    /* Cor de fundo mais escura ao passar o mouse */
}

/* Estilo de inputs de números e texto */
.property__inputs input[type="number"] {
    width: 60px;
    /* Largura de 60px */
    text-align: center;
    /* Alinha o texto no centro */
    border: 1px solid #ddd;
    /* Borda fina cinza claro */
    border-radius: 4px;
    /* Bordas arredondadas */
    font-size: 16px;
    /* Tamanho da fonte de 16px */
    padding: 5px;
    /* Padding de 5px */
}

.property__inputs input[type="text"] {
    width: 60px;
    /* Largura de 60px */
    text-align: center;
    /* Alinha o texto no centro */
    border: 1px solid #ddd;
    /* Borda fina cinza claro */
    border-radius: 4px;
    /* Bordas arredondadas */
    font-size: 16px;
    /* Tamanho da fonte de 16px */
    padding: 5px;
    /* Padding de 5px */
}

/* Estilos para o wrapper de inputs */
.input-wrapper {
    display: flex;
    /* Flexbox para layout flexível */
    align-items: center;
    /* Alinha os itens verticalmente ao centro */
    gap: 0.5rem;
    /* Espaço de 0.5rem entre os itens */
}

/* Estilos adicionais para texto dentro de inputs */
.property__inputs span {
    font-size: 1rem;
    /* Tamanho de fonte de 1rem */
}

.step2 {
    display: flex;
    /* Flexbox para layout flexível */
    font-weight: bold;
    /* Fonte em negrito */
    align-items: center;
    /* Alinha os itens verticalmente ao centro */
    justify-content: center;
    /* Alinha os itens horizontalmente ao centro */
}

.Step2__container {
    display: flex;
    /* Flexbox para layout flexível */
    gap: 20px;
    /* Espaço de 20px entre os itens */
}

.Step2__item {
    flex: 1;
    /* Flexível, ocupando 1 unidade de espaço */
    display: flex;
    /* Flexbox para layout flexível */
    flex-direction: column;
    /* Organiza os itens em uma coluna */
}

.step2 input {
    border: 2px solid #ededed;
    /* Borda de 2px cinza claro */
    border-radius: 7px;
    /* Bordas arredondadas */
    margin-top: 13px;
    /* Margem superior de 13px */
    padding: 1rem;
    /* Padding interno de 1rem */
}

/* Estilos da etapa 3 */
.step3 {
    display: flex;
    /* Flexbox para layout flexível */
    flex-direction: column;
    /* Organiza os itens em uma coluna */
}

.step3 input,
textarea {
    border: 3px solid #ededed;
    /* Borda de 3px cinza claro */
    border-radius: 7px;
    /* Bordas arredondadas */
    margin-top: 13px;
    /* Margem superior de 13px */
    padding: 1rem;
    /* Padding interno de 1rem */
}

/* Media query para dispositivos maiores que 1200px */
@media (max-width: 1200px) {
    .container {
        flex-direction: column;
        /* Muda para coluna em telas menores */
        padding: 15px;
        /* Padding reduzido para 15px */
    }

    .Etapas {
        width: 90%;
        /* Largura ajustada para 90% */
    }

    .add__imoveis__box {
        width: 100%;
        /* Largura de 100% */
        padding: 20px;
        /* Padding ajustado */
    }
}

/* Media query para telas com largura de até 992px */
@media (max-width: 992px) {
    .internal__container {
        padding: 10px;
        /* Padding ajustado para 10px */
    }

    .select__status-btn {
        font-size: 14px;
        /* Tamanho da fonte ajustado */
    }

    .property__select,
    button,
    .property__inputs input[type="number"],
    .property__inputs input[type="text"] {
        width: 100%;
        /* Largura ajustada para 100% */
    }

    .step2 {
        flex-direction: column;
        /* Organiza os itens em coluna */
    }

    .Step2__container {
        flex-direction: column;
        /* Organiza os itens em coluna */
    }

    .counter__controls button {
        width: 35px;
        /* Reduz a largura para 35px */
        height: 35px;
        /* Reduz a altura para 35px */
    }
}

/* Media query para telas com largura de até 768px */
@media (max-width: 768px) {
    .container {
        height: auto;
        /* Altura ajustada */
        max-height: none;
        /* Remove a altura máxima */
    }

    .Etapas {
        width: 100%;
        /* Largura de 100% */
    }

    .add__imoveis__box {
        height: auto;
        /* Altura ajustada */
        padding: 15px;
        /* Padding ajustado */
    }

    .select__status-btn {
        font-size: 14px;
        /* Tamanho da fonte ajustado */
        margin: 5px 0;
        /* Margem ajustada */
    }

    .property__select {
        padding: 8px;
        /* Padding ajustado */
    }

    .counter__group,
    .area__group {
        flex-direction: column;
        /* Organiza os itens em coluna */
        gap: 1rem;
        /* Espaço ajustado */
    }

    .counter,
    .area-input {
        width: 100%;
        /* Largura ajustada para 100% */
    }

    .input-wrapper {
        flex-direction: column;
        /* Organiza os itens em coluna */
        align-items: flex-start;
        /* Alinha os itens à esquerda */
    }

    .step3 input,
    .step3 textarea {
        padding: 0.8rem;
        /* Padding ajustado */
    }
}

/* Media query para telas menores que 480px */
@media (max-width: 480px) {
    .container {
        padding: 10px;
        /* Padding ajustado para 10px */
    }

    .Etapas {
        width: 100%;
        /* Largura de 100% */
        padding: 10px;
        /* Padding ajustado */
    }

    .add__imoveis__box {
        padding: 10px;
        /* Padding ajustado */
    }

    h1,
    h2,
    h3 {
        font-size: 18px;
        /* Reduz o tamanho da fonte para 18px */
    }

    .select__status-btn {
        padding: 10px;
        /* Padding ajustado */
        font-size: 12px;
        /* Tamanho da fonte ajustado */
    }

    .property__select,
    .property__inputs input[type="number"],
    .property__inputs input[type="text"],
    button {
        font-size: 14px;
        /* Tamanho da fonte ajustado */
    }

    .counter__controls button {
        width: 30px;
        /* Largura ajustada para 30px */
        height: 30px;
        /* Altura ajustada para 30px */
    }
}
</style>
