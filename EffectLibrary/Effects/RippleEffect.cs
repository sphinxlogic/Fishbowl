﻿//-----------------------------------------------------------------------
// <copyright file="RippleEffect.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// <summary>
//     WPF Extensible Effect
// </summary>
//-----------------------------------------------------------------------
namespace EffectLibrary
{
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Effects;

    /// <summary>
    /// This is the implementation of an extensible framework ShaderEffect which loads
    /// a shader model 2 pixel shader. Dependecy properties declared in this class are mapped
    /// to registers as defined in the *.ps file being loaded below.
    /// </summary>
    public class RippleEffect : ShaderEffect
    {
        /// <summary>
        /// Gets or sets the Center variable within the shader.
        /// </summary>
        public static readonly DependencyProperty CenterProperty = DependencyProperty.Register("Center", typeof(Point), typeof(RippleEffect), new UIPropertyMetadata(new Point(0.5, 0.5), PixelShaderConstantCallback(0)));

        /// <summary>
        /// Gets or sets the Amplitude variable within the shader.
        /// </summary>
        public static readonly DependencyProperty AmplitudeProperty = DependencyProperty.Register("Amplitude", typeof(double), typeof(RippleEffect), new UIPropertyMetadata(0.1, PixelShaderConstantCallback(1)));
        
        /// <summary>
        /// Gets or sets the Frequency variable within the shader.
        /// </summary>
        public static readonly DependencyProperty FrequencyProperty = DependencyProperty.Register("Frequency", typeof(double), typeof(RippleEffect), new UIPropertyMetadata(50.0, PixelShaderConstantCallback(2)));

        /// <summary>
        /// Gets or sets the Phase variable within the shader.
        /// </summary>
        public static readonly DependencyProperty PhaseProperty = DependencyProperty.Register("Phase", typeof(double), typeof(RippleEffect), new UIPropertyMetadata(0.0, PixelShaderConstantCallback(3)));

        /// <summary>
        /// Gets or sets the input brush used in the shader.
        /// </summary>
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(RippleEffect), 0);

        /// <summary>
        /// The pixel shader instance.
        /// </summary>
        private static PixelShader pixelShader = new PixelShader();

        /// <summary>
        /// Initializes static members of the RippleEffect class.
        /// </summary>
        static RippleEffect()
        {
            pixelShader.UriSource = Global.MakePackUri("ShaderBytecode/ripple.fx.ps");
        }

        /// <summary>
        /// Initializes a new instance of the RippleEffect class.
        /// </summary>
        public RippleEffect()
        {
            this.PixelShader = pixelShader;

            UpdateShaderValue(CenterProperty);
            UpdateShaderValue(AmplitudeProperty);
            UpdateShaderValue(PhaseProperty);
            UpdateShaderValue(FrequencyProperty);
            UpdateShaderValue(InputProperty);
        }

        /// <summary>
        /// Gets or sets the center variable within the shader.
        /// </summary>
        public Point Center
        {
            get { return (Point)GetValue(CenterProperty); }
            set { SetValue(CenterProperty, value); }
        }

        /// <summary>
        /// Gets or sets the Amplitude variable within the shader.
        /// </summary>
        public double Amplitude
        {
           get { return (double)GetValue(AmplitudeProperty); }
           set { SetValue(AmplitudeProperty, value); }
        }

        /// <summary>
        /// Gets or sets the frequency variable within the shader.
        /// </summary>
        public double Frequency
        {
            get { return (double)GetValue(FrequencyProperty); }
            set { SetValue(FrequencyProperty, value); }
        }

        /// <summary>
        /// Gets or sets the Phase variable within the shader.
        /// </summary>
        public double Phase
        {
           get { return (double)GetValue(PhaseProperty); }
           set { SetValue(PhaseProperty, value); }
        }

        /// <summary>
        /// Gets or sets the input used within the shader.
        /// </summary>
        public Brush Input
        {
           get { return (Brush)GetValue(InputProperty); }
           set { SetValue(InputProperty, value); }
        }
    }
}
