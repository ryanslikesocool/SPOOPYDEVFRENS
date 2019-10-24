Requires 2D Animation and 2D PSD Importer packages.

'Newt Ghost' is the prefab for the character; it contains the character(which should be hidden) and a quad that displays a rendered texture of the character, to allow the character to be translucent without the separate parts clipping with each other. The 'Ghost Texture' RenderTexture can be adjusted to a higher resolution if needed.

For the translucent ghost effect, the main camera needs to have its culling mask set to exclude layer 31(this can be changed, as long as you also change the layer of the 'Ghost Camera' culling mask and the layer of the 'Do not scale' sprites. Alternatively, the sprites can be used without the effect by setting them to the default render layer.

The 'Ghost Render Quad' can be moved and scaled as needed, and can be removed from the prefab as long as the 'Do not scale' object remains unscaled. It can be billboarded, etc, independently of the animated hierarchy. The 'Do not scale' object can be stuck wherever, it doesn't need to be visible.

Happy Halloween!
		-Pinball