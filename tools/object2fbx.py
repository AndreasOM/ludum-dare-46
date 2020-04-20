import bpy
import sys

def export_object_as_fbx( name, filename ):    
    bpy.ops.object.select_all(action='DESELECT')
    object = bpy.data.objects[ name ]
    print(object)
    object.select_set(True)
    bpy.context.view_layer.objects.active = object

    fbx_name = bpy.path.abspath( filename ) # :TODO: use unity asset path here
    print(fbx_name)

    # :TODO: experiment with batch_mode=GROUP
    bpy.ops.export_scene.fbx(filepath=fbx_name, axis_forward='-Z', axis_up='Y', use_selection=True, bake_space_transform=True,)


argv = sys.argv
argv = argv[argv.index('--')+1:]
print(argv)

name = argv[0]
filename = argv[1]

print( name, filename )
export_object_as_fbx( name, filename )
#export_object_as_fbx( 'ArrowUp', '//arrow.fbx' )

