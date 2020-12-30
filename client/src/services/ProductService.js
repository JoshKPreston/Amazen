import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class ProductService {
  async getAll() {
    try {
      const res = await api.get('api/products')
      AppState.products = res.data
    } catch (error) {
      logger.log(error)
    }
  }

  async getOne(id) {
    try {
      const res = await api.get('api/products/' + id)
      AppState.activeProduct = res.data
    } catch (error) {
      logger.log(error)
    }
  }

  async create(newProduct) {
    try {
      const res = await api.post('api/products', newProduct)
      AppState.products = [...AppState.products, res.data]
    } catch (error) {
      logger.log(error)
    }
  }
}

export const productService = new ProductService()
