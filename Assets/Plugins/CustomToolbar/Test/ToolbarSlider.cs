// Decompiled with JetBrains decompiler
// Type: UnityEditor.UIElements.ToolbarButton
// Assembly: UnityEditor.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A2C55C0F-1D20-42D9-93A6-0A1B2E64637B
// Assembly location: /Volumes/NKStudioHD/Applications/Unity/Hub/Editor/6000.0.18f1/Unity.app/Contents/Managed/UnityEngine/UnityEditor.CoreModule.dll
// XML documentation location: /Volumes/NKStudioHD/Applications/Unity/Hub/Editor/6000.0.18f1/Unity.app/Contents/Managed/UnityEngine/UnityEditor.CoreModule.xml


#nullable disable
using System;
using UnityEngine.Internal;
using UnityEngine.UIElements;

namespace UnityEditor.UIElements
{
    /// <summary>
    ///        <para>
    /// A button for the toolbar. For more information, refer to.
    /// </para>
    ///      </summary>
    public class ToolbarSlider : Slider
    {
        /// <summary>
        ///        <para>
        /// USS class name of elements of this type.
        /// </para>
        ///      </summary>
        public new static readonly string ussClassName = "unity-toolbar-slider";

        /// <summary>
        ///        <para>
        /// Constructor.
        /// </para>
        ///      </summary>
        public ToolbarSlider()
        {
            Toolbar.SetToolbarStyleSheet((VisualElement)this);
            this.RemoveFromClassList(Slider.ussClassName);
            this.AddToClassList(ToolbarSlider.ussClassName);
        }
        
        [ExcludeFromDocs]
        [Serializable]
        public new class UxmlSerializedData : Slider.UxmlSerializedData
        {
            public override object CreateInstance() => (object)new ToolbarSlider();
        }

        /// <summary>
        ///        <para>
        /// Instantiates a ToolbarButton using the data read from a UXML file.
        /// </para>
        ///      </summary>
        [Obsolete("UxmlFactory is deprecated and will be removed. Use UxmlElementAttribute instead.", false)]
        public new class UxmlFactory : UnityEngine.UIElements.UxmlFactory<ToolbarSlider, ToolbarSlider.UxmlTraits>
        {
        }

        /// <summary>
        ///        <para>
        /// Defines UxmlTraits for the ToolbarButton.
        /// </para>
        ///      </summary>
        [Obsolete("UxmlTraits is deprecated and will be removed. Use UxmlElementAttribute instead.", false)]
        public new class UxmlTraits : Slider.UxmlTraits
        {
        }
    }
}