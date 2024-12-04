import { createRouter, createWebHistory } from "vue-router";
import Home from "../views/Home.vue";

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: "/",
      name: "home",
      component: Home,
    },
    {
      path: "/Login",
      name: "Login",
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import("@/views/Login.vue"),
    },
    {
      path: "/Cadastro",
      name: "Cadastro",
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import("@/views/Cadastro.vue"),
    },
    {
      path: "/AnunciarSeuImovel",
      name: "AnunciarSeuImovel",
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import("@/views/AnunciarSeuImovel.vue"),
    },
    {
      path: "/ViewImovel",
      name: "ViewImovel",
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import("@/views/ViewImovel.vue"),
    },
    {
      path: "/ViewOneImovelCasa",
      name: "ViewOneImovelCasa",
      component: () => import("@/views/ViewOneImovelCasa.vue"),
      props: true,
    },
    {
      path: "/ViewOneImovelApartamento",
      name: "ViewOneImovelApartamento",
      component: () => import("@/views/ViewOneImovelApartamento.vue"),
      props: true,
    },
    {
      path: "/ViewOneImovelComercial",
      name: "ViewOneImovelComercial",
      component: () => import("@/views/ViewOneImovelComercial.vue"),
      props: true,
    },
    {
      path: "/ViewOneImovelLote",
      name: "ViewOneImovelLote",
      component: () => import("@/views/ViewOneImovelLote.vue"),
      props: true,
    },
    {
      path: "/ViewOneImovelTerreno",
      name: "ViewOneImovelTerreno",
      component: () => import("@/views/ViewOneImovelTerreno.vue"),
      props: true,
    },
    {
      path: "/ViewOneImovelRural",
      name: "ViewOneImovelRural",
      component: () => import("@/views/ViewOneImovelRural.vue"),
      props: true,
    },
    {
      path: "/UsuarioPage",
      name: "UsuarioPage",
      component: () => import("@/views/UsuarioPage.vue"),
    },
    {
      path: "/Contato",
      name: "Contato",
      component: () => import("@/views/Contato.vue"),
    },
    {
      path: "/SobreNos",
      name: "SobreNos",
      component: () => import("@/views/SobreNos.vue"),
    },
  ],
});

export default router;
