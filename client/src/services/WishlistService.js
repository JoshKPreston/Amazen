import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class WishlistService {
  async getAll() {
    try {
      const res = await api.get('api/wishlists')
      AppState.wishlists = res.data
    } catch (error) {
      logger.log(error)
    }
  }

  async getOne(id) {
    try {
      const res = await api.get('api/wishlists/' + id)
      AppState.activeWishlist = res.data
    } catch (error) {
      logger.log(error)
    }
  }
}

export const productService = new WishlistService()
