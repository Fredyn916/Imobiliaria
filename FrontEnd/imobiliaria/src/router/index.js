import { createRouter, createWebHistory } from 'vue-router'
import Home from '../views/Home.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home,
    },
    {
      path: '/Login',
      name: 'Login',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('@/views/Login.vue'),
    },
    {
      path: '/Cadastro',
      name: 'Cadastro',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('@/views/Cadastro.vue'),
    },
    {
      path: '/Anunciar',
      name: 'Anunciar',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('@/views/Anunciar.vue'),
    },
    {
      path: '/ViewImovel',
      name: 'ViewImovel',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('@/views/ViewImovel.vue'),
    },
    {
      path: "/ViewOneImovelCasa",
      name: "ViewOneImovelCasa",
      component: () => import('@/views/ViewOneImovelCasa.vue'),
      props: true,
    },
  ],
})

export default router
