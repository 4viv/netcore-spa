import Vue from 'vue'
import VueRouter from 'vue-router'
import Default from '../components/Default'
import OrderIndex from '../components/orders/OrderIndex'
import ClientIndex from '../components/clients/ClientIndex'
import ProductIndex from '../components/products/ProductIndex'
import UserIndex from '../components/users/UserIndex'
import store from '../store/index'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'default',
    component: Default
  },
  {
    path: '/orders', // Ruta
    name: 'orders', // Componente al que va
    component: OrderIndex,
    beforeEnter: authorization
  },
  {
    path: '/clients',
    name: 'clients',
    component: ClientIndex
  },
  {
    path: '/products',
    name: 'products',
    component: ProductIndex
  },
  {
    path: '/users',
    name: 'users',
    // Antes de entrar valida autorizacion
    component: UserIndex,
    beforeEnter: authorization
  }
]

// Autorizar ruta de Admin
function authorization(to, from, next) {
  let user = store.state.user;

  // a donde va de donde viene y lo que ejecuta 
  if (user) {
    if (to.name === 'users' && !user.roles.includes('Admin')) {
      // si el rol del usuario no es admin
      return next('/');
    }
  }

  return next(); // continuar flujo
}

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
