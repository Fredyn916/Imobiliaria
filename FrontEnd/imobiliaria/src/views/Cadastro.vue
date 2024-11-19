<template>
    <NavBar />
    <NavBarUsuarios />
    <div class="page-container">
        <div class="form-container">
            <h1 class="form-title">Cadastre-se</h1>
            <form @submit="CreateUsuario" class="user-form">
                <div v-if="message"
                    :class="['message', message === 'Sucesso ao Cadastrar o usuario.' ? 'success' : 'error']">
                    {{ message }}
                </div>

                <div class="form-group">
                    <label for="nome">Nome :</label>
                    <input type="text" id="nome" v-model="nome" required />
                </div>

                <div class="form-group">
                    <label for="idade">Idade :</label>
                    <input type="text" id="idade" v-model="idade" required />
                </div>

                <div class="form-group">
                    <label for="genero">Genero :</label>
                    <select id="genero" v-model="genero" required>
                        <option value="" disabled>Selecione...</option>
                        <option value="Masculino">Masculino</option>
                        <option value="Feminino">Feminino</option>
                    </select>
                </div>

                <div class="form-group">
                    <label for="numero">Digite o seu numero :</label>
                    <input type="text" id="numero" v-model="numero" />
                </div>

                <div class="form-group">
                    <label for="cep">Digite o seu CEP :</label>
                    <input type="text" id="cep" v-model="cep" />
                </div>

                <div class="form-group">
                    <label for="identificacao">Identificação (CPF, CNPJ, CNH, CTPS, RG, etc...):</label>
                    <input type="text" id="identificacao" v-model="identificacao" required />
                </div>

                <div class="form-group">
                    <label for="username">Username :</label>
                    <input type="text" id="username" v-model="username" required />
                </div>

                <div class="form-group">
                    <label for="password">Password :</label>
                    <input type="password" id="password" v-model="password" required />
                </div>

                <button type="submit" class="submit-btn">Cadastrar Usuário</button>
            </form>

            <h1>Já tem um cadastro?</h1>
            <RouterLink to="Login" class="Entry__Bnt">Clique aqui para logar</RouterLink>
        </div>
    </div>
</template>

<script>
export default {
    name: 'FormPostUsuario',
    data() {
        return {
            nome: '',
            idade: '',
            genero: '',
            cep: '',
            rua: '',
            numero: '',
            bairro: '',
            cidade: '',
            unidadeFederativa: '',
            identificacao: '',
            username: '',
            password: '',
            message: '',
        };
    },
    methods: {

        async CreateUsuario(e) {
            e.preventDefault();

            const cepResponse = await this.GetCep();

            const data = {
                nome: this.nome,
                idade: this.idade,
                genero: this.genero,
                cep: cepResponse.cep,
                rua: cepResponse.logradouro,
                numero: this.numero,
                bairro: cepResponse.bairro,
                cidade: cepResponse.localidade,
                unidadeFederativa: cepResponse.uf,
                identificacao: this.identificacao,
                username: this.username,
                password: this.password,
            };

            const dataJson = JSON.stringify(data);
            console.log(dataJson);

            // Envia os dados para a API
            const response = await fetch('https://localhost:7082/Usuario/AdicionarUsuario', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: dataJson,
            });

            if (response.status === 200) {
                this.message = 'Sucesso ao Cadastrar o usuário.';
            } else {
                this.message = 'Erro ao Cadastrar o usuário.';
            }
        },

        // Função para buscar o CEP
        async GetCep() {
            try {
                const response = await fetch(`https://viacep.com.br/ws/${this.cep}/json/`);
                if (!response.ok) {
                    this.message = 'Erro ao buscar o CEP.';
                    return null;
                }
                const data = await response.json();
                return data;
            } catch (error) {
                console.error('Erro ao buscar o CEP:', error);
                this.message = 'Erro ao buscar o CEP.';
                return null;
            }
        }
    },
};
</script>

<style scoped>
/* Seu estilo aqui */
</style>
