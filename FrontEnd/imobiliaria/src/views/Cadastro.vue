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

                <!-- Nome -->
                <div class="form-group">
                    <label for="nome">Nome :</label>
                    <input type="text" id="nome" v-model="nome" required />
                </div>

                <!-- Idade -->
                <div class="form-group">
                    <label for="Idade">Idade :</label>
                    <input type="text" id="Idade" v-model="Idade" required />
                </div>

                <!-- Gênero -->
                <div class="form-group">
                    <label for="Genero">Genero :</label>
                    <select id="Genero" v-model="Genero" required>
                        <option value="" disabled>Selecione...</option>
                        <option value="Masculino">Masculino</option>
                        <option value="Feminino">Feminino</option>
                    </select>
                </div>

                <!-- CEP -->
                <div class="form-group">
                    <label for="CEP">Digite o seu CEP :</label>
                    <input type="text" id="CEP" v-model="CEP" required /> <button type="button" @click="GetCep" class="cep-form">Buscar</button>
                </div>

                <!-- Identificação -->
                <div class="form-group">
                    <label for="Identificacao">Identificação (CPF, CNPJ, CNH, CTPS, RG, etc...):</label>
                    <input type="text" id="Identificacao" v-model="Identificacao" required />
                </div>

                <!-- Username -->
                <div class="form-group">
                    <label for="username">Username :</label>
                    <input type="text" id="username" v-model="username" required />
                </div>

                <!-- Password -->
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
            CEP: '',
            identificacao: '',
            username: '',
            password: '',
            message: '',
            endereco: '', // Para armazenar o endereço do CEP
        };
    },
    methods: {

        
        async CreateUsuario(e) {
            e.preventDefault();
            const data__returned__CEP = []
            const data = {
                nome: this.nome,
                idade: this.idade,
                genero: this.genero,
                cep: this.cep,
                identificacao: this.identificacao,
                username: this.username,
                password: this.password,
            };

            const dataJson = JSON.stringify(data);

            const response = await fetch('https://localhost:7248/Usuario/adicionar-usuario', {
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

        async GetCep() {
            try {
                const response = await fetch(`https://viacep.com.br/ws/${this.CEP}/json/`);
                if (!response.ok) { throw new Error('Erro ao buscar o CEP'); }
                const data = await response.json();
                data__returned__CEP = data;
            }
            catch (error) { console.error('Erro:', error); }
        }
    },
};
</script>

<style scoped>
/* Adicione seu estilo personalizado aqui */
</style>