<template>
    <div class="Center__Container">
        <div class="container" id="container">
            <!-- Formulário de Cadastro -->
            <div class="form-container register-container">
                <form @submit.prevent="handleRegister">
                    <h1>Cadastre-se</h1>
                    
                    <div class="form-control">
                        <input type="text" v-model="nome" placeholder="Nome" />
                        <small v-if="nomeError">{{ nomeError }}</small>
                    </div>

                    <div class="form-control">
                        <input type="text" v-model="idade" placeholder="Idade" />
                        <small v-if="idadeError">{{ idadeError }}</small>
                    </div>

                    <div class="form-control">
                        <select v-model="genero" placeholder="Gênero">
                            <option value="" disabled>Selecione...</option>
                            <option value="Masculino">Masculino</option>
                            <option value="Feminino">Feminino</option>
                        </select>
                    </div>

                    <div class="form-control">
                        <input type="text" v-model="cep" placeholder="CEP" />
                        <small v-if="cepError">{{ cepError }}</small>
                    </div>

                    <div class="form-control">
                        <input type="text" v-model="identificacao" placeholder="Identificação (CPF, etc.)" />
                        <small v-if="identificacaoError">{{ identificacaoError }}</small>
                    </div>

                    <div class="form-control">
                        <input type="text" v-model="username" placeholder="Username" />
                        <small v-if="usernameError">{{ usernameError }}</small>
                    </div>

                    <div class="form-control">
                        <input type="password" v-model="password" placeholder="Senha" />
                        <small v-if="passwordError">{{ passwordError }}</small>
                    </div>

                    <button type="submit">Cadastrar</button>
                </form>
            </div>

            <!-- Formulário de Login (se necessário) -->
            <div class="form-container login-container">
                <form @submit.prevent="loginUsuario">
                    <h1>Login</h1>

                    <div class="form-control2">
                        <input type="text" v-model="loginEmail" placeholder="Email" />
                        <small v-if="loginEmailError">{{ loginEmailError }}</small>
                    </div>

                    <div class="form-control2">
                        <input type="password" v-model="loginPassword" placeholder="Senha" />
                        <small v-if="loginPasswordError">{{ loginPasswordError }}</small>
                    </div>

                    <button type="submit">Entrar</button>

                </form>
            </div>

            <!-- Painel de transição -->
            <div class="overlay-container">
                <div class="overlay">
                    <div class="overlay-panel overlay-left">
                        <h1>Já tem uma conta?</h1>
                        <p>Se já possui conta, entre agora e comece a usar!</p>
                        <button class="ghost" @click="showLoginPanel">Login</button>
                    </div>

                    <div class="overlay-panel overlay-right">
                        <h1>Comece sua jornada!</h1>
                        <p>Ainda não tem uma conta? Registre-se agora e aproveite!</p>
                        <button class="ghost" @click="showRegisterPanel">Registrar</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    name: 'CadastroLogin',
    data() {
        return {
            nome: '',
            idade: '',
            genero: '',
            cep: '',
            identificacao: '',
            username: '',
            password: '',
            loginEmail: '',
            loginPassword: '',
            rememberMe: false,
            nomeError: '',
            idadeError: '',
            cepError: '',
            identificacaoError: '',
            usernameError: '',
            passwordError: '',
            loginEmailError: '',
            loginPasswordError: ''
        };
    },
    methods: {
        showRegisterPanel() {
            document.getElementById('container').classList.add('right-panel-active');
        },
        showLoginPanel() {
            document.getElementById('container').classList.remove('right-panel-active');
        },
        async handleRegister() {
            this.nomeError = '';
            this.idadeError = '';
            this.cepError = '';
            this.identificacaoError = '';
            this.usernameError = '';
            this.passwordError = '';

            // Validação dos campos
            if (this.nome.length < 3) {
                this.nomeError = '*Nome deve ter pelo menos 3 caracteres.';
            }

            if (!this.cep || this.cep.length !== 8) {
                this.cepError = '*CEP inválido.';
            }
            if (this.identificacao.length < 11) {
                this.identificacaoError = '*Identificação inválida.';
            }
            if (this.username.length < 4) {
                this.usernameError = '*Username deve ter pelo menos 4 caracteres.';
            }
            if (this.password.length < 8) {
                this.passwordError = '*Senha deve ter pelo menos 8 caracteres.';
            }

            // Se algum erro ocorreu, não submeter o formulário
            if (this.nomeError || this.idadeError || this.cepError || this.identificacaoError || this.usernameError || this.passwordError) {
                return;
            }
            
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
        },

        async loginUsuario() {
            this.loginEmailError = '';
            this.loginPasswordError = '';


            // Se algum erro ocorreu, não submeter o formulário
            if (this.loginEmailError || this.loginPasswordError) {
                return;
            }

            // Simulando um login para um teste
            const data = {
                username: this.loginEmail,
                password: this.loginPassword
            };

            const dataJson = JSON.stringify(data);

            const req = await fetch('https://localhost:7082/Usuario/LogarUsuario', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: dataJson,
            });

            const usuario = await req.json();
            
            console.log('Resposta da API:', usuario);

            if (usuario.password === this.loginPassword) {
                this.$store.dispatch('setUsuario', usuario);
                this.$router.push('/UsuarioPage');
            }
        },

        isValidEmail(email) {
            const emailRegex = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$/;
            return emailRegex.test(email);
        },

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
    }
};
</script>

<style scoped>
@import url("https://fonts.googleapis.com/css2?family=Poppins:wght@100;200;300;400;500;600;700;800;900&display=swap");

* {
    /* margin: 0;
    padding: 0; */
    box-sizing: border-box;
}

body {
    background-color: #686c78;
    display: flex;
    justify-content: center;
    align-items: center;
    flex-direction: column;
    font-family: "Poppins", sans-serif;
    overflow: hidden;
    height: 100vh;
}

h1 {
    font-weight: 700;
    letter-spacing: -1.5px;
    margin: 0;
    margin-bottom: 15px;
}

h1.title {
    font-size: 45px;
    line-height: 45px;
    margin: 0;
    text-shadow: 0 0 10px rgba(16, 64, 74, 0.5);
}

p {
    font-size: 15px;
    font-weight: 400;
    line-height: 20px;
    letter-spacing: 0.5px;
    margin: 20px 0 30px;
    text-shadow: 0 0 10px rgba(16, 64, 74, 0.5);
}

span {
    font-size: 14px;
    margin-top: 20px;
}

a {
    color: #333;
    font-size: 14px;
    text-decoration: none;
    margin: 15px 0;
    transition: 0.3s ease-in-out;
}

a:hover {
    color: #4bb6b7;
}

.Center__Container{
    width: 100%;
    height: 100vh;
    display: flex;
    align-items: center;
    justify-content: center;

}

.content {
    display: flex;
    width: 100%;
    height: 50px;
    align-items: center;
    justify-content: space-around;
}

.content .checkbox {
    display: flex;
    align-items: center;
    justify-content: center;
}

.content input {
    accent-color: #333;
    width: 12px;
    height: 12px;
}

.content label {
    font-size: 14px;
    user-select: none;
    padding: 5px;
}

button {
    position: relative;
    border-radius: 20px;
    border: 1px solid #686c78;
    background-color: #686c78;
    color: #fff;
    font-size: 15px;
    font-weight: 700;
    margin: 20px;
    padding: 12px 80px;
    letter-spacing: 1px;
    text-transform: capitalize;
    transition: 0.3s ease-in-out;
    cursor: pointer;
}

button:hover {
    letter-spacing: 3px;
}

button:active {
    transform: scale(0.95);
}

button:focus {
    outline: none;
}

button.ghost {
    background-color: rgba(255, 255, 255, 0.2);
    border: 2px solid #fff;
    color: #fff;
}

#login i {
    position: absolute;
    left: 50px;
}

#register i {
    position: absolute;
    right: 50px;
}

button.ghost i {
    position: absolute;
    opacity: 1;
    transition: 0.3s ease-in-out;
    z-index: 6;
}

button.ghost i.register {
    right: 70px;
}

button.ghost i.login {
    left: 70px;
}

form {
    background-color: #fff;
    display: flex;
    align-items: center;
    justify-content: center;
    flex-direction: column;
    padding: 0 50px;
    height: 100%;
    text-align: center;
}

input {
    background-color: #fff;
    outline: none;
    border: none;
    border-bottom: 2px solid #adadad;
    padding: 12px 0px;
    margin: 8px 0;
    width: 100%;
}

.container {
    border-radius: 25px;
    box-shadow: 0 14px 28px rgba(0, 0, 0, 0.25), 0 0px 10px rgba(0, 0, 0, 0.22);
    position: relative;
    overflow: hidden;
    width: 768px;
    max-width: 100%;
    min-height: 500px;
}

.form-container {
    position: absolute;
    top: 0;
    height: 100%;
    transition: all 0.6s ease-in-out;
}

.form-control {
    width: 100%;
    position: relative;
}

.form-control2 {
    width: 100%;
    position: relative;
}

.form-control2 span {
    position: absolute;
    border-bottom: 3px solid #2691d9;
    left: 0;
    bottom: 8px;
    width: 0%;
    transition: all 0.3s ease;
}

.form-control2 input:focus~span {
    width: 100%;
}

.form-control small {
    color: red;
    position: absolute;
    top: 50px;
    left: 0;
    font-size: 12px;
    z-index: 100;
}

.form-control span {
    position: absolute;
    border-bottom: 3px solid #2691d9;
    left: 0;
    bottom: 8px;
    width: 0%;
    transition: all 0.3s ease;
}

.form-control input:focus~span {
    width: 100%;
}

.form-control2 small {
    color: red;
    position: absolute;
    top: 50px;
    left: 0;
    font-size: 12px;
    z-index: 100;
}

.form-control2 span {
    position: absolute;
    border-bottom: 3px solid #2691d9;
    left: 0;
    bottom: 8px;
    width: 0%;
    transition: all 0.3s ease;
}

.form-control2 input:focus~span {
    width: 100%;
}

.login-container {
    left: 0;
    width: 50%;
    z-index: 2;
}

.container.right-panel-active .login-container {
    transform: translateX(100%);
}

.register-container {
    /* position: relative; */
    left: 0;
    width: 50%;
    opacity: 0;
    z-index: 1;
}

.container.right-panel-active .register-container {
    transform: translateX(100%);
    opacity: 1;
    z-index: 5;
    animation: show 0.6s;
}

@keyframes show {

    0%,
    49.99% {
        opacity: 0;
        z-index: 1;
    }

    50%,
    100% {
        opacity: 1;
        z-index: 5;
    }
}

.overlay-container {
    position: absolute;
    top: 0;
    left: 50%;
    width: 50%;
    height: 100%;
    overflow: hidden;
    transition: transform 0.6s ease-in-out;
    z-index: 100;
}

.container.right-panel-active .overlay-container {
    transform: translate(-100%);
}

.overlay {
    background-image: url("https://www.quintoandar.com.br/guias/wp-content/uploads/2023/06/casa-de-luxo-7-1.jpg");
    background-repeat: no-repeat;
    background-size: cover;
    background-position: 0 0;
    color: #fff;
    position: relative;
    left: -100%;
    height: 100%;
    width: 200%;
    transform: translateX(0);
    transition: transform 0.6s ease-in-out;
}

.overlay::before {
    content: "";
    position: absolute;
    left: 0;
    right: 0;
    top: 0;
    bottom: 0;
    background: linear-gradient(to top,
            rgba(46, 94, 109, 0.4) 40%,
            rgba(46, 94, 109, 0));
}

.container.right-panel-active .overlay {
    transform: translateX(50%);
}

.overlay-panel {
    position: absolute;
    display: flex;
    align-items: center;
    justify-content: center;
    flex-direction: column;
    padding: 0 40px;
    text-align: center;
    top: 0;
    height: 100%;
    width: 50%;
    transform: translateX(0);
    transition: transform 0.6s ease-in-out;
}

.overlay-left {
    transform: translateX(-20%);
}

.container.right-panel-active .overlay-left {
    transform: translateX(0);
}

.overlay-right {
    right: 0;
    transform: translateX(0);
}

.container.right-panel-active .overlay-right {
    transform: translateX(20%);
}

.social-container {
    margin: 20px 0;
}

.social-container a {
    border: 1px solid #dddddd;
    border-radius: 50%;
    display: inline-flex;
    justify-content: center;
    align-items: center;
    margin: 0 5px;
    height: 40px;
    width: 40px;
    transition: 0.3s ease-in-out;
}

.social-container a:hover {
    border: 1px solid #4bb6b7;
}
</style>