import './assets/main.css'; // Importando o CSS principal do seu projeto

import { createApp } from 'vue';
import App from './App.vue';
import router from './router';
import { store } from './store/store';

// Importando as bibliotecas necessárias do Font Awesome
import { library } from '@fortawesome/fontawesome-svg-core';
import { faFacebook, faTwitter, faInstagram } from '@fortawesome/free-brands-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome';

// Adicionando os ícones à biblioteca
library.add(faFacebook, faTwitter, faInstagram);

// Criando a instância do aplicativo Vue
const app = createApp(App);

// Usando o Vuex e o Vue Router
app.use(store);
app.use(router);

// Registrando o componente global do FontAwesomeIcon
app.component('font-awesome-icon', FontAwesomeIcon);

// Montando a aplicação
app.mount('#app');
